using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBasic : MonoBehaviour
{
    public Transform target;//The target that the boss gaze will follow

    public int bossMaxHealth = 35;//boss's max health
    public float fireRate = 2f;//the base fire rate of the boss's shooting 

    int bossCurrentHealth;//The boss's vurrent health
    float fireCountDown = 0f;//the cool down on shooting 

    public float fireTime;//total time the boss fires for

    public GameObject bulletPrefab;
    public Transform firePoint;


    private void Start()
    {
        bossCurrentHealth = bossMaxHealth;//sets current healt to max health
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
