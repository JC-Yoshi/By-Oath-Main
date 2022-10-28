using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    Transform newPosition;
    void Start()
    {
        SetPosition();
    }

   
    void SetPosition()
    {
        newPosition = this.transform;
    }

// Update is called once per frame
void Update()
    {
        newPosition = this.transform;
    }
}
