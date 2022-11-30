using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionPromptUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _promptText;
    //For text background
    [SerializeField] private GameObject _uiPanel;



    void Start()
    {
        //_uiPanel.SetActive(false);
    }

   
    void Update()
    {
        
    }

    public bool IsDisplayed = false;

   public void SetUp(string promptText)
    {
        _promptText.text = promptText;
        _uiPanel.SetActive(true);
        IsDisplayed = true;
    }

    public void Close()
    {
        _uiPanel.SetActive(false);
        IsDisplayed = false;
    }
}
