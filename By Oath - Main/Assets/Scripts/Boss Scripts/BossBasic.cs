using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBasic : MonoBehaviour
{
    public Transform target;
    public int bossMaxHealth = 35;
    int bossCurrentHealth;


    private void Start()
    {
        bossCurrentHealth = bossMaxHealth;
    }

    private void Update()
    {
        FaceTarget();
    }

    void FaceTarget()//does math magic so that the boss is allways faceing the player 
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }

    public void EnemyTakeDamage(int Damage)
    {
        bossCurrentHealth -= Damage;// current health - damage of player

        //play the damaged animation if there is one

        if (bossCurrentHealth <= 0)//if health is less then or equal to 0 call die
        {
            BossDie();
        }
    }

    void BossDie()
    {
        Debug.Log("Boss is dead");


    }



}
