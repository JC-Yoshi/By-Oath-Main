using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSounds : MonoBehaviour
{
    // NOTE FOR FUTURE:
    // This could be triggered from the Animation Events by adding "Footstep" events.
    // For now it's using a timer as a placeholder system.

    public AudioClip[] sounds;
    public AudioSource audSrc;
    public Rigidbody rb;

    // could use Aimation Events instead of timer in future?
    public float timer_duration;
    private float timer;


    void Start()
    {
        audSrc = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        // if player is moving and grounded, update the timer
        if (rb.velocity.magnitude > 0.1)
        {
            timer += Time.deltaTime;
        }

        if (timer > timer_duration)
        {
            PlayRandomSound();
            timer = 0;
        }
    }


    void PlayRandomSound()
    {
        //Debug.Log("Footstep played!");
        audSrc.PlayOneShot(sounds[Random.Range(0, sounds.Length)]);
    }


}