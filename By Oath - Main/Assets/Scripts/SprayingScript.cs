using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayingScript : MonoBehaviour
{
    public ParticleSystem ScepterSpray;

    public void Anim_Spray()
    {
        ScepterSpray.Play();
    }
   
}
