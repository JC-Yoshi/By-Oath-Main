using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSound : MonoBehaviour
{
    public AudioClip[] Deathsounds;
    public AudioSource audSrc;



    // Start is called before the first frame update
    void Start()
    {
        audSrc = GetComponent<AudioSource>();

    }

    public void play_Deathsound()
    {
        Debug.Log("DeathSound is Played");
        audSrc.PlayOneShot(Deathsounds[Random.Range(0, Deathsounds.Length)]);
    }
}
            

    
