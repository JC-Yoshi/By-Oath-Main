using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    public bool cross1;
    public bool cross2;
    public bool cross3;
    //checks to stop errors
    bool cross1Active = false;
    bool cross2Active = false;
    bool cross3Active = false;

    public Image Cross1;//the image for each cross
    public Image Cross2;
    public Image Cross3;

    // Start is called before the first frame update
    void Start()
    {
        //dissables each cross image on start 
        Cross1.enabled = false;
        Cross2.enabled = false;
        Cross3.enabled = false;
    }


    public void CrossPickup1()
    {
        bool cross1 = true;
        Debug.Log("picked up cross 1");
        if (cross1 == true)
        {
            
            //trigger next wave spawn
        }
    }
    public void CrossPickup2()
    {
        bool cross2 = true;
        Debug.Log("picked up cross 2");
        if (cross2 == true)
        {
            
            //trigger next wave spawn
        }
    }
    public void CrossPickup3()
    {
        bool cross3 = true;
        Debug.Log("picked up cross 3");

        if (cross3 == true)
        {
           
            //trigger wave spawn 
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (cross1Active == false)//checks to see if the image is active
        {
            if (cross1 == true)//checks to see if the cross has been picked up
            {
                Cross1.enabled = true;//enables the image

                cross1Active = true;//changes the check variable to true
            }
        }
        if (cross2Active == false)
        {


            if (cross2 == true)
            {
                Cross2.enabled = true;
                cross2Active = true;
            }
        }

        if (cross3Active == false)
        {


            if (cross3 == true)
            {
                Cross3.enabled = true;
                cross3Active = true;
            }
        }



    }
}
