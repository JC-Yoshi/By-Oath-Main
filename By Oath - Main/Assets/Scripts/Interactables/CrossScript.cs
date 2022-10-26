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
        Debug.Log("collecing cross");

        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        if (inventory.cross1 == false)
        {
            inventory.cross1 = true;
            inventory.CrossPickup1();
            return true;
        }


        if (inventory.cross1 == true)
        {
            if (inventory.cross2 == false)
            {
                inventory.cross2 = true;
                inventory.CrossPickup2();
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
                }
            }
        }

        return true;
    }
}


