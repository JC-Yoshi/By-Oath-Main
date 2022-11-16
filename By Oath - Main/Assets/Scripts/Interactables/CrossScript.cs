using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossScript : MonoBehaviour, IInteractable
{
    Inventory inventory;


    [SerializeField] private string prompt;
    public AudioClip[] crossPickupSounds;
    public GameObject crossFX;
    private AudioSource audSrc;

    public string InteractionPrompt => prompt;



    void Start()
    {
        audSrc = GetComponent<AudioSource>();
    }


    void ActivateCross()
    {
        audSrc.Stop();
        audSrc.loop = false;
        audSrc.PlayOneShot(crossPickupSounds[Random.Range(0, crossPickupSounds.Length)]);
    }


    void DeactivateCross()
    {
        // used to do this to "clean up the cross"
        GetComponent<CrossScript>().enabled = false;//disables the crossScript
        //this.gameObject.SetActive(false);  //disables the game object
        //Destroy(gameObject);//destroys the game object  

        // disable mesh renderer
        GetComponent<MeshRenderer>().enabled = false;
        // disable collider
        GetComponent<Collider>().enabled = false;
        // disable FX
        crossFX.SetActive(false);

    }


    public bool Interact(Interactor interactor)
    {
        Debug.Log("collecing cross");//debug check log

        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();//accses the inventory script

        //runs checks for crosses as the player works there way though collecting them, triggering the next wave as they go 
        if (inventory.cross1 == false)
        {
            ActivateCross();
            inventory.cross1 = true;//makes cross1 be collected 
            inventory.CrossPickup1();//runs the pickup function, which triggers the UI changes and next wave spawn 
     
            DeactivateCross();
            return true;
        }

        //Above coments are repeted for each method below
        if (inventory.cross1 == true)//triggers for the seccond cross pick up
        {
            if (inventory.cross2 == false)
            {
                ActivateCross();
                inventory.cross2 = true;
                inventory.CrossPickup2();

                DeactivateCross();
                return true;
            }
        }

        if (inventory.cross1 == true)//triggers for the third cross pick up
        {
            if (inventory.cross2 == true)
            {
                if (inventory.cross3 == false)
                {
                    ActivateCross(); 
                    inventory.cross3 = true;
                    inventory.CrossPickup3();

                    DeactivateCross();
                    return true;
                }
            }
        }

        return true;
    }
}


