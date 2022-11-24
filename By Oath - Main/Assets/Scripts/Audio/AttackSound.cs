using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSound : MonoBehaviour
{
    public AudioClip[] Attacksounds;
    public AudioClip[] SpecialAttackSounds;
    public AudioSource audSrc;


    void Start()
    {
        // get reference to audiosource game component
        audSrc = GetComponent<AudioSource>();
        //GameObject.Find("PA_HandsByOath").GetComponent<AudioSource>();
    }

    public void play_Attacksound()
    {
        //Debug.Log("Play Audio Source");


        audSrc.PlayOneShot(Attacksounds[Random.Range(0, Attacksounds.Length)]);
        //audSrc.Play();

    }

    public void play_SpecialAttack_sound()
    {
        audSrc.PlayOneShot(SpecialAttackSounds[Random.Range(0, SpecialAttackSounds.Length)]);
    }



}
