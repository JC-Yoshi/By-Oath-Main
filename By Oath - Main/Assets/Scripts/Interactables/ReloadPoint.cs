using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadPoint : MonoBehaviour, IInteractable


{
    PlayerCombat playerCombat;
    

   [ SerializeField] private string prompt;

    public string InteractionPrompt => prompt;
    


    public bool Interact(Interactor interactor)
    {

        Debug.Log("reloading");

        //playerCombat = gameObject.GetComponent<PlayerCombat>();

        playerCombat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();//allows this script to accsess the playerCombat script
        playerCombat.Reload();//calls reload

        return true;

    }
}
