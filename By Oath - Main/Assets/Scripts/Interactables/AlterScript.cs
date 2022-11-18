using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AlterScript :MonoBehaviour, IInteractable
{
    public GameObject bOSS;

   
    [SerializeField] private string prompt;
    public string InteractionPrompt => prompt;

    public bool Interact(Interactor interactor)//allows interaction
    {
      
        bOSS.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        return true;
    } 
    
    
}