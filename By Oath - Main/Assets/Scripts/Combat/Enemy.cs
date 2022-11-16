using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 5;//max health of enemy
    int currentHealth;// the enemys current health
    public int attackDamage;//The enemys attack damage
    public Transform attackPoint;//the point that the enemy attacks from
    public float attackRange = 0.6f;//the enemys attack range
    public float attackRate = 2f;//how many times the enemy can attack per second
    float nextAttackTime = 0f;//how long till the next attack
    public LayerMask playerLayer;// defines what the player is
    public AudioClip[] attackClips;
    private AudioSource audSrc;
    public bool isAlive = true;

    PlayerCombat playerCombat;

    void Start()
    {
        currentHealth = maxHealth;//sets current health to max on start
        audSrc = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Time.time >= nextAttackTime)//if enough time has passed then the enemy can attack
        {
            Attack();

            nextAttackTime = Time.time + 1f / attackRate;//once attacked 1/attackrate is how long till the next attack

        }

    }

    public void Attack()
    {
        Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, playerLayer);


        //damage them
        foreach (Collider player in hitPlayer)
        {
            //damage the enemies
            Debug.Log("Hit" + player.name);

            //Play attack sound
            if (attackClips.Length > 0)
            {
                Debug.Log("Attack sound play!");
                audSrc.PlayOneShot(attackClips[Random.Range(0, attackClips.Length)]);
            }

            // player.GetComponent<PlayerCombat>().PlayerTakeDamage(attackDamage);//calls the enemy script and allows damage to be done 
            playerCombat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();//allows this script to accsess the playerCombat script
            playerCombat.PlayerTakeDamage(attackDamage);
        }
        
    }

    public void EnemyTakeDamage(int Damage)
    {
        currentHealth -= Damage;// current health - damage of player

        //play the damaged animation if there is one

        if (currentHealth <= 0)//if health is less then or equal to 0 call die
        {
            EnemyDie();
        }
    }

    void EnemyDie()//die function 
    {
        isAlive = false;
        Debug.Log("Enemy Died");
        //death animation

        //dissable the enemy

        GetComponent<EnemyMove>().enabled = false;
        GetComponent<Collider>().enabled = false;



        this.enabled = false;

        Destroy(gameObject);

    }
    public void Spawn()
    {
        this.gameObject.SetActive(true);
    }

    private void OnDrawGizmosSelected()//draws the attack range
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}