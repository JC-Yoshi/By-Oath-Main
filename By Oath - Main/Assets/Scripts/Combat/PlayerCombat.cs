using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
  //  public Animator animator;

    public Transform attackPoint; // The point from which the wepons range is calculated
    public float mainAttackRange = 0.5f;// the range the wepon can attack up to
    public float seccondAttackRange = 1.75f;
    public LayerMask enemyLayers;// defines what an enemy is

    public int mainAttackDamage = 1;// the players damage
    public int seccondAttackDamage = 10;
    public int amoCountMax = 5; //players amo count 
    int amoCount = 0;

    private void Start()
    {
        amoCount = amoCountMax;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))//triggers when left mouse click is clicked
        {
            if (amoCount >= 0)
            {
                MainAttack();
            } 
            else
            Debug.Log("Out of amo");  //will play a ui element telling the player to reload
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if ( amoCount == amoCountMax)
            {
                SecondAttack();
            }
            else
                MainAttack();

        }
        
      //  if(Input.GetKeyDown(KeyCode.E))//temp reload mechanic until reload points are completed
       // {
       //     Reload();
      //  }


    }

    void MainAttack()// the attack function 
    {
        //play the attack animation, to be fully implemented once animator is ready
        // animator.SetTrigger("Attack"); // name of the trigger will go in the brakets


        //detect enemies in range

        amoCount--;

        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, mainAttackRange, enemyLayers);


        //damage them
        foreach (Collider enemy in hitEnemies)
        {
            //damage the enemies
            Debug.Log("Hit" + enemy.name);

            enemy.GetComponent<Enemy>().TakeDamage(mainAttackDamage);//calls the enemy script and allows damage to be done 
        }
    }

    void SecondAttack()
    {
        //play the attack animation, to be fully implemented once animator is ready
        // animator.SetTrigger("Attack"); // name of the trigger will go in the brakets


        //detect enemies in range

        amoCount = 0;

        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, seccondAttackRange, enemyLayers);


        //damage them
        foreach (Collider enemy in hitEnemies)
        {
            //damage the enemies
            Debug.Log("Hit" + enemy.name);

            enemy.GetComponent<Enemy>().TakeDamage(seccondAttackDamage);//calls the enemy script and allows damage to be done 
        }
    }

   public void Reload()
   {

        Debug.Log("Reloaded");
        amoCount = amoCountMax;
   }

    private void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPoint.position, mainAttackRange);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position , seccondAttackRange);
    }
}
