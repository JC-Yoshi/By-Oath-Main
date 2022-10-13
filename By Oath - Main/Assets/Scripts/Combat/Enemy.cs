using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 5;//max health of enemy
    int currentHealth;// the enemys current health


    void Start()
    {
        currentHealth = maxHealth;//sets current health to max on start
    }

    public void TakeDamage(int Damage)
    {
        currentHealth -= Damage;// current health - damage of player

        //play the damaged animation if there is one

        if (currentHealth <= 0)//if health is less then or equal to 0 call die
        {
            Die();
        }
    }

    void Die()//die function 
    {
        Debug.Log("Enemy Died");
        //death animation

        //dissable the enemy

        GetComponent<EnemyMove>().enabled = false;
        GetComponent<Collider>().enabled = false;

        this.enabled = false;
    }
}