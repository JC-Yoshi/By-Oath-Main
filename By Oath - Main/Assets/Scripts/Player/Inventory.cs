using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
   public bool cross1;
   public bool cross2;
   public bool cross3;

    // Start is called before the first frame update
    void Start()
    {

        bool cross1 = false;
        bool cross2 = false;
        bool cross3 = false;

    }


    public void CrossPickup1()
    {
        bool cross1 = true;
        Debug.Log("picked up cross 1");
        if(cross1 == true)
        {
            //change UI
            //trigger next wave spawn
        }
    }
    public void CrossPickup2()
    {
        bool cross2 = true;
        Debug.Log("picked up cross 2");
        if(cross2 ==true)
        {
            //change UI
            //trigger next wave spawn
        }
    }
    public void CrossPickup3()
    {
        bool cross3 = true;
        Debug.Log("picked up cross 3");

        if (cross3 == true)
        {
            //change UI
            //trigger next wave spawn
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
