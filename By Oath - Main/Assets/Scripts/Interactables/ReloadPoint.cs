using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadPoint : MonoBehaviour, IInteractable


{
    PlayerCombat playerCombat;

    float nextReloadTime;
    [Header("1 per X sec")]
    public float reloadRate = 10f;

   [ SerializeField] private string prompt;

    public string InteractionPrompt => prompt;
    


    public bool Interact(Interactor interactor)
    {

        //Debug.Log("reloading");

        //playerCombat = gameObject.GetComponent<PlayerCombat>();

        playerCombat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();//allows this script to accsess the playerCombat script
        if (Time.time >= nextReloadTime)
        {
            playerCombat.Reload();//calls reload

            nextReloadTime = Time.time + 1f * reloadRate;
        }
        else
            Debug.Log("Bowl is on cooldown");
        

        return true;

    }
}
