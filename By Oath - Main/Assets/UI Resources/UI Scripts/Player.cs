using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    public int currentWater;
    public int maxWater = 5;
    public HolyMeter holyMeter;

    // Start is called before the first frame update
    void Start()
    {
        currentWater = maxWater;
        holyMeter.SetMaxWater(maxWater);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            TakeDamage(20);

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoseWater(1);
        }
    }
    void TakeDamage(int damage)
    {
        {
            currentHealth -= damage;

            healthBar.SetHealth(currentHealth);
        }
    }
    void LoseWater(int waterLoss)
    {
        {
            currentWater -= waterLoss;
            holyMeter.SetWater(currentWater);
        }
    }
}
