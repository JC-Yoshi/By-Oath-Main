using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    private enum State
    {
        Idle,
        Active,
        BattleOver,
    }

    [SerializeField] private ColliderTrigger colliderTrigger;
    [SerializeField] private Wave[] waveArray;

    private State state;

    private void Awake()
    {
        state = State.Idle;
    }
    // Start is called before the first frame update
    private void Start()
    {
        colliderTrigger.OnPlayerEnterTrigger += ColliderTrigger_OnPlayerEnterTrigger;
    }

    private void ColliderTrigger_OnPlayerEnterTrigger(object sender, System.EventArgs e)
    {
        if (state == State.Idle)
        {
            StartBattle();
            colliderTrigger.OnPlayerEnterTrigger -= ColliderTrigger_OnPlayerEnterTrigger;
        }

    }

    private void StartBattle()
    {
        Debug.Log("StartBattle");
        state = State.Active;
    }
    private void Update()
    {
        switch (state)
        {
            case State.Active:

                foreach (Wave wave in waveArray)
                {
                    wave.Update();
                }
                TestBattleOver();
                break;
        }
    }
    private void TestBattleOver()
    {
       if (state == State.Active)
        {
            if (AreWavesOver())
            {
                // Battle is over!
                state = State.BattleOver;
                Debug.Log("Battle is Over!");
            }
        }
    }
    private bool AreWavesOver()
    {
        foreach (Wave wave in waveArray)
        {
            if (wave.IsWaveOver())
            {
                // wave is over
            }
            else
            {
                // wave not over
                return false;
            }
        }
        return true;
    }
    // Represents a single Enemy Spawn Wave
    [System.Serializable]
    private class Wave
    {
        [SerializeField] private EnemySpawn[] enemySpawnArray;
        [SerializeField] private float timer;

        public void Update()
        {
            if (timer >= 0)
            {
              timer = Time.deltaTime;
                if (timer <= 0)
                {
                    SpawnEnemies();
                }
            }
        }
        private void SpawnEnemies()
        {
            foreach (EnemySpawn enemySpawn in enemySpawnArray)
            {
                enemySpawn.Spawn();
            }
        }
        // logic for testing to see if the wave is over
        public bool IsWaveOver()
        {
            if (timer < 0)
            {
                // wave spawned
                foreach (EnemySpawn enemySpawn in enemySpawnArray)
                {
                    if (enemySpawn.IsAlive())
                    {
                        return false;
                    }
                }
                return true;
            }
            // enemies have not spawned yet
            else
            {
                return false;
            }
        }
    }
}
