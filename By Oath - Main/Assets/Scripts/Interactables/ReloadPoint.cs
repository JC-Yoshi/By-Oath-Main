using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadPoint : MonoBehaviour, IInteractable

{
    [SerializeField] private bool isActive = true;

    PlayerCombat playerCombat;

    float nextReloadTime;
    [Header("1 per X sec")]
    public float reloadRate = 10f;

    [SerializeField] private string prompt;

    public string InteractionPrompt => prompt;

    private AudioSource audSrc;
    [SerializeField] GameObject fountainWater;

    void Start()
    {
        audSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        // check if fountain should be re-activated
        if (Time.time >= nextReloadTime  &&  isActive == false)
        {

            isActive = true;
            audSrc.volume = 1.0f;
            fountainWater.SetActive(true);
        }
    }



    public bool Interact(Interactor interactor)
    {

        //Debug.Log("reloading");

        //playerCombat = gameObject.GetComponent<PlayerCombat>();

        playerCombat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();//allows this script to accsess the playerCombat script
        if (Time.time >= nextReloadTime)
        {
            playerCombat.Reload();//calls reload

            // turn off fountain visuals and audio
            isActive = false;
            audSrc.volume = 0.0f;
            fountainWater.SetActive(false);

            nextReloadTime = Time.time + 1f * reloadRate;
        }
        else
            Debug.Log("Bowl is on cooldown");
        

        return true;

    }
}
