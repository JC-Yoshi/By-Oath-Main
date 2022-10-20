using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackPointOrientation : MonoBehaviour
{

    public Transform orientation;

    private void Start()
    {
        GetComponent<Transform>().rotation = orientation.rotation;
    }

    private void Update()
    {
        GetComponent<Transform>().rotation = orientation.rotation;
    }


}
