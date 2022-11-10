using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{

    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");     //calling the audio source
        if ( musicObj.Length > 1)                                                   
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        //allowing to keep the gameobject to transition from main menu scene to graveyard scene
    }
}
