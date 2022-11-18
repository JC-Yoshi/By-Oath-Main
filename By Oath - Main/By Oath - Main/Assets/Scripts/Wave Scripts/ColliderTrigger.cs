using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColliderTrigger : MonoBehaviour
{
    public event EventHandler OnPlayerEnterTrigger;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = collider.GetComponent<Player>();
        if (player != null)
        {
            // Player inside trigger area!
            Debug.Log("Player inside trigger!");
            OnPlayerEnterTrigger?.Invoke(this, EventArgs.Empty);
        }
    }
}
