using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayingScript : MonoBehaviour
{
    public ParticleSystem SprayEffect;
    public ParticleSystem BurstEffect;
    public void Anim_Spray()
    {
        SprayEffect.Play();
        BurstEffect.Play();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
