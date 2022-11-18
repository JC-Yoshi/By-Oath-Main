using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayingScript : MonoBehaviour
{
    public ParticleSystem ScepterSpray;
    public ParticleSystem BigScepterSpray;
    public ParticleSystem BigSprayRings;

    
    public void Anim_SpecialSpray()
    {
        BigScepterSpray.Play();
        BigSprayRings.Play();
    }
    
    
    public void Anim_Spray()
    {
        ScepterSpray.Play();
    }
   
}
