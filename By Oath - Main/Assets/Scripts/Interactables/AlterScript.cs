using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlterScript :MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;
    public string InteractionPrompt => prompt;

    public bool Interact(Interactor interactor)//allows interaction
    {
        Debug.Log("Teleporing to boss");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//handels scene transition


        return true;
    }
}