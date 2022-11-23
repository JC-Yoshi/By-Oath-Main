using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Spawn Enemy with a nice Dissolve Effect
public class EnemySpawn : MonoBehaviour
{
    public event EventHandler OnDead;
    //private EnemyMain enemyMain;

    private void Awake()
    {
        // to be filled
    }
    // Start is called before the first frame update
    void Start()
    {
        // to be filled
    }
    private void HealthSystem_OnDead(object sender, System.EventArgs e)
    {
        // to be filled
    }

    public void Spawn()
    {
        this.gameObject.SetActive(true);

    }

    public bool IsAlive()
    {
        // to be filled
        throw new NotImplementedException();
    }
}
