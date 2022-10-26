using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bullet : MonoBehaviour
{
    PlayerCombat playerCombat;//refference to playerCombat script

    BossBasic bossBasic;//refference to the bossBasic cript
   
    [SerializeField]
    NavMeshAgent navMeshAgent;


    public int attackDamage = 4;//the bullets damage 
    public float hitRange = 0.5f;//the bullets hit range
    public LayerMask Player;//the layer mask that the player is in 
    public Transform bulletPosition; // the bullets current position
    float timeAlive = 0f;

    float attackRate = 3f;//the rate the "bullets" attack
    float nextAttackTime = 0f;//there next attack time 



    private void Start()
    {             
        if (navMeshAgent == null)//checks to see if theres a nav mesh
        {
            Debug.Log("no connected navmesh to" + gameObject.name);
        }
       

        bossBasic = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossBasic>();//gives acces to the bossBasic script
            
        timeAlive = bossBasic.fireTime; //makes the time alive == to the fire time 
        

    }

    public void SetDestination(Transform destination)//the set destination function
    {
        if (destination != null)//if the destination isn't null
        {
            Vector3 targetVector3 = destination.transform.position;//gets the destination and marks the position
            navMeshAgent.SetDestination(targetVector3);//sets the new vec3 as the target destination 
        }
        else
        {
            Debug.Log("The Set Destination is broken");//thoughs debug if it cant find a destination 
        }
    }

    private void Update()
    {

        if (Time.time >= nextAttackTime)//if enough time has passed then the enemy can attack
        {
            Damage();
            nextAttackTime = Time.time + 1f / attackRate;//once attacked 1/attackrate is how long till the next attack
        }

        if (Time.time >= timeAlive)//if the time the bullets have been "alive" is equal to the boss total fireing time then destroy all bullets
        {
            Die();   
        }
    }

    void Damage()//dealing damage to the player 
    {
        Collider[] hitPlayer = Physics.OverlapSphere(bulletPosition.position, hitRange, Player);//detects if contact is made and stores in array 

        foreach (Collider player in hitPlayer)//go's though the array 
        {
            //damage the Player
            Debug.Log("Hit" + player.name);

            
            playerCombat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();//allows this script to accsess the playerCombat script
            playerCombat.PlayerTakeDamage(attackDamage);//calls the players take damage function 

        }
    }

    void Die()//destroyes the bullet 
    {

        Debug.Log("Bullet destroyed");//debug log for inital testing 
        GetComponent<Bullet>().enabled = false;//disables the bullet script
        Destroy(gameObject);//destroyes the game object

       
        return;


    }

    private void OnDrawGizmosSelected()//draws the HitBox range
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(bulletPosition.position, hitRange);
    }

}
