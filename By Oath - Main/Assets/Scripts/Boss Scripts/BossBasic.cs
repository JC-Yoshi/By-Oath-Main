using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBasic : MonoBehaviour
{
    public Transform target;//The target that the boss gaze will follow

    public int bossMaxHealth = 35;//boss's max health


    int bossCurrentHealth;//The boss's vurrent health

    int thirdOfBossHealth;//calculates a third of the bosses health
    int healthThreshold1;//when boss has lost a third of there health thell start shooting again
    int healthThreshold2;//when boss has lost two thirds of there health thell start shooting again

    float fireCountDown = 0f;//the cool down on shooting 

    bool Phase1 = false;
    bool Phase2 = false;

    [Header("Fire rate per Phase")]//the base fire rate of the boss's shooting 
    public float fireRate;
    public float fireRate2;
    public float fireRate3;




    [Header("Fire time per Phase")]//total time the boss fires for each phase 
    public float fireTime;
    public float fireTime2;
    public float fireTime3;

    public GameObject bulletPrefab;
    public Transform firePoint;


    private void Start()
    {
        bossCurrentHealth = bossMaxHealth;//sets current healt to max health
        thirdOfBossHealth = bossMaxHealth / 3;
        healthThreshold1 = bossMaxHealth - thirdOfBossHealth;
        healthThreshold2 = healthThreshold1 - thirdOfBossHealth;

    }
    private void Update()
    {
        FaceTarget();//runs the face target script
        if (Time.time < fireTime)
        {
            if (fireCountDown <= 0)//checks the the cool down is 0 and then it can shoot
            {
                Shoot();//runs shoot
                fireCountDown = 1f / fireRate; //sets new countdown 
            }
            fireCountDown -= Time.deltaTime;//starts counting down 

        }

    }

    void Shoot()//shoots
    {


        //  Debug.Log("The Boss is shooting");//debug log to say that the boss is shooting 
        GameObject bulletG0 = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Bullet bullet = bulletG0.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.SetDestination(target);
        }

    }
    void FaceTarget()//does math magic so that the boss is allways faceing the player 
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }

    public void BossTakeDamage(int Damage)
    {
        bossCurrentHealth -= Damage;// current health - damage of player
        Debug.Log("Boss taking damage");
        //play the damaged animation if there is one
        if (Phase1 == false)
        {
            if (bossCurrentHealth <= healthThreshold1)
            {
                Debug.Log("boss has lost first third of health");
                //start shooting again
                fireTime = Time.time + fireTime2;
                fireRate = fireRate2;
                Shoot();

                bossCurrentHealth = healthThreshold1;

                Debug.Log("the bosses current health is" + bossCurrentHealth);
                Phase1 = true;
            }
        }

        if (Phase1 == true)
        {
            if (Phase2 == false)
            {
                if (bossCurrentHealth <= healthThreshold2)
                {
                    //start shooting again
                    Debug.Log("boss has lost second third of health");
                    //start shooting again
                    fireTime = Time.time + fireTime3;
                    fireRate = fireRate3;
                    Shoot();

                    bossCurrentHealth = healthThreshold2;

                    Debug.Log("the bosses current health is" + bossCurrentHealth);

                    Phase2 = true;

                }
            }
        }


        if (bossCurrentHealth <= 0)//if health is less then or equal to 0 call die
        {
            BossDie();
        }
    }

    void BossDie()
    {
        Debug.Log("Boss is dead");

        GetComponent<BossBasic>().enabled = false;
        Destroy(gameObject);
        return;

        //trigger win screen 
    }



}
