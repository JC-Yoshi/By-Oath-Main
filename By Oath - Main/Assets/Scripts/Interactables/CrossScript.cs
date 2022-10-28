using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossScript : MonoBehaviour, IInteractable
{
    Inventory inventory;


    [SerializeField] private string prompt;
    

    public string InteractionPrompt => prompt;


    
    public bool Interact(Interactor interactor)
    {
        Debug.Log("collecing cross");//debug check log

        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();//accses the inventory script

        //runs checks for crosses as the player works there way though collecting them, triggering the next wave as they go 
        if (inventory.cross1 == false)
        {
            inventory.cross1 = true;//makes cross1 be collected 
            inventory.CrossPickup1();//runs the pickup function, which triggers the UI changes and next wave spawn 

           // GameObject.FindGameObjectWithTag("Cross1").SetActive(true);
            

            GetComponent<CrossScript>().enabled = false;//disables the crossScript
                this.gameObject.SetActive(false);  //disables the game object
                Destroy(gameObject);//destroys the game object  
            return true;
        }

        //Above coments are repeted for each method 
        if (inventory.cross1 == true)
        {
            if (inventory.cross2 == false)
            {
                inventory.cross2 = true;
                inventory.CrossPickup2();

              //  GameObject.FindGameObjectWithTag("Cross2").SetActive(true);

                GetComponent<CrossScript>().enabled = false;
                this.gameObject.SetActive(false);
                Destroy(gameObject);

             

                return true;
            }
        }

        if (inventory.cross1 == true)
        {
            if (inventory.cross2 == true)
            {
                if (inventory.cross3 == false)
                {
                    inventory.cross3 = true;
                    inventory.CrossPickup3();

                   // GameObject.FindGameObjectWithTag("Cross3").SetActive(true);

                    GetComponent<CrossScript>().enabled = false;
                    this.gameObject.SetActive(false);
                    Destroy(gameObject);

                 

                    return true;
                }
            }
        }

        return true;
    }
}


