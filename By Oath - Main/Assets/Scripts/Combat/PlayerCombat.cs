using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCombat : MonoBehaviour
{
    Enemy myEnemy;
    BossBasic bossBasic;

    //  public Animator animator;

    

    public Transform attackPoint; // The point from which the wepons range is calculated
    [Header("Main Attack")]
    public float mainAttackRange = 0.5f;// the range the wepon can attack up to
    public int mainAttackDamage = 1;// the players damage

    [Header("Powwer Attack")]
    public int seccondAttackDamage = 10;//seccondarys attack damage
    public float seccondAttackRange = 1.75f;//seccondary attacks range

    [Header("HUD Elements")]
    public HolyMeter holyMeter;
    public HealthBar healthBar;

    [Header("Menu Elements")]
    public GameObject pauseMenu;
    public GameObject optionsMenu;

    [Header("Enemy Layers")]
    public LayerMask minionLayers;// defines what an enemy is
    public LayerMask bossLayer;//defines the boss

    [Header("Ammo")]
    public int amoCountMax = 5; //players amo count 
    int amoCount = 0;//keeps track of the players current ammo count
    [Header("Health")]
    public int maxHealth = 15;//max health the player can have 
    [SerializeField]int currentHealth = 1;//the players current health

    private void Start()
    {

        amoCount = amoCountMax;

        holyMeter.SetMaxWater(amoCountMax);

        currentHealth = maxHealth;

        healthBar.SetMaxHealth(maxHealth);

    }

    // Update is called once per frame
    void Update()
    {

        if (pauseMenu.active == false)
        {
            if (optionsMenu.active == false)
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

                if (Input.GetKeyDown(KeyCode.Mouse1))//secondary attack
                {
                    if (amoCount == amoCountMax)//only attacks if player has max ammo
                    {
                        SecondAttack();
                    }
                    else
                        Debug.Log("Not enough ammo to powwer attack");//will play a ui element telling the player they dont have enough ammo

                }
            }

        }


    }

    void MainAttack()// the mainAttack function 
    {
        //play the attack animation, to be fully implemented once animator is ready
        // animator.SetTrigger("Attack"); // name of the trigger will go in the brakets


        //detect enemies in range

        amoCount--;
        holyMeter.SetWater(amoCount);//calling UI scripts
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, mainAttackRange, minionLayers);

        //damage them
        foreach (Collider enemy in hitEnemies)
        {
            //damage the enemies
            Debug.Log("Hit" + enemy.name);

            enemy.GetComponent<Enemy>().EnemyTakeDamage(mainAttackDamage);//calls the enemy script and allows damage to be done   

        }

        Collider[] hitBoss = Physics.OverlapSphere(attackPoint.position, mainAttackRange, bossLayer);//detects any hit bosses

        foreach (Collider boss in hitBoss)//loops over hit bosses
        {
            Debug.Log("Hit" + boss.name);
            boss.GetComponent<BossBasic>().BossTakeDamage(mainAttackDamage);//damages the boss

        }
    }

    void SecondAttack()//seccondary attack, right mouse click
    {
        //play the attack animation, to be fully implemented once animator is ready
        // animator.SetTrigger("Attack"); // name of the trigger will go in the brakets


        //detect enemies in range

        amoCount = 0;
        holyMeter.SetWater(amoCount);
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, seccondAttackRange, minionLayers);


        //damage them
        foreach (Collider enemy in hitEnemies)//loops over hit enemys
        {
            //damage the enemies
            Debug.Log("Hit" + enemy.name);

            enemy.GetComponent<Enemy>().EnemyTakeDamage(seccondAttackDamage);//calls the enemy script and allows damage to be done 
        }

        Collider[] hitBoss = Physics.OverlapSphere(attackPoint.position, seccondAttackRange, bossLayer);//detects any hit bosses

        //damage them
        foreach (Collider boss in hitBoss)//loops over hit bosses
        {
            //damage the enemies
            Debug.Log("Hit" + boss.name);
            boss.GetComponent<BossBasic>().BossTakeDamage(seccondAttackDamage);//damages the boss
        }
    }

    public void Reload()
    {

        Debug.Log("Reloaded");//logs a reload
        amoCount = amoCountMax;//sets current amo = to max amo

        holyMeter.SetWater(amoCount);
    }

    public void Heal()
    {
        int healValue =  maxHealth / 2;//calculates half the players max health 

        if(currentHealth!= maxHealth)
            currentHealth += healValue;//if the player is below half health add half there total health to there current health 
    }

    public void PlayerTakeDamage(int Damage)
    {
        currentHealth -= Damage;// current health - damage of enemy

        //play the damaged animation if there is one

        healthBar.SetHealth(currentHealth);


        if (currentHealth <= 0)//if health is less then or equal to 0 call die
        {
            PlayerDie();
        }
    }

    void PlayerDie()//die function 
    {
        Debug.Log("player is dead");
        //death animation??

        //Play death screen       

        
        Cursor.lockState = CursorLockMode.None;//unlocks the cursor to the center of the screen
        Cursor.visible = true;//make the mouse visable 

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + -1);

    }


    private void OnDrawGizmosSelected()//draws the main attacks range
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPoint.position, mainAttackRange);
    }

    private void OnDrawGizmos()//draws the seccondary attacks range
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, seccondAttackRange);
    }
}
