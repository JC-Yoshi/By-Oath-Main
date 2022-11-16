using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlaySoundFromCollection : MonoBehaviour
{
    public AudioClip[] sounds;
    public AudioSource audSrc;

    public float timer_min;
    public float timer_max;
    public float timer_duration;
    private float timer;

    void Start()
    {
        // get reference to things
        audSrc = GetComponent<AudioSource>();

        // set first timer value
        SetNewTimer();
    }


    void Update()
    {
        // count up the timer
        timer += Time.deltaTime;

        // if the timer reaches the limit, play random sound
        if (timer > timer_duration)
        {
            PlayRandomSound();
        }
    }

    public void SetNewTimer()
    {
        timer_duration = Random.Range(timer_min, timer_max);
        timer = 0;
    }

    void PlayRandomSound()
    {
        //Debug.Log("Sound played!");
        audSrc.PlayOneShot(sounds[Random.Range(0, sounds.Length)]);
        SetNewTimer();
    }

}