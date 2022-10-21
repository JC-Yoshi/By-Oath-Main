using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    PlayerCombat playerCombat;

    private Transform target;//the bullets target 
    public int attackDamage = 4;//the bullets damage 
    public float speed = 80f;//the bullets speed
   // public Transform bulletPosition;
  //  public float hitRange = 0.5f;
  //  public LayerMask obstical;

    public float shootingTime = 5f;//how long the bullet stays alive 
    
    float currentTime;

    private void Start()
    {
       currentTime = Time.time;
    }
    public void Seek(Transform Target)
    {
        target = Target;//allows it to inherit its target from the boss 
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Timer>();
        
        if (target == null)//if theres no target it will destroy the target 
        {
            Destroy(gameObject);
            return;
        }
        if (currentTime >= shootingTime)//if the bullets been alive for to long it'll despawn 
        {
            Debug.Log("Bullet has despawned");

            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;//gives the bullet the direction 
        float distanceThisFrame = speed * Time.deltaTime;//calculates how far to travel 

        if (direction.magnitude <= distanceThisFrame)//calculates if the target is hit 
        {

            HitTarget();//runs hit target
            Destroy(gameObject);//destroys the bullet
            return;//leaves 
        }
        /*if(Physics.OverlapSphere(bulletPosition.position, hitRange , obstical) )//if it colliders with an obstical destroy it 
        {
            Destroy(gameObject);
            return;
        }*/

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);//calculates were to travel 

    }

    void HitTarget()
    {
        Debug.Log("Hit target");

        playerCombat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();//allows this script to accsess the playerCombat script
        playerCombat.PlayerTakeDamage(attackDamage);//deals damage 
    }


}
