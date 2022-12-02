using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{

    public GameObject nextCross;

    private enum State
    {
        Idle,
        Active,
        BattleOver,
    }

    [SerializeField] private ColliderTrigger colliderTrigger;
    [SerializeField] private EnemyGroup[] enemyGroups;
    private AudioSource audSrc;
    [SerializeField] private AudioClip[] bellSounds;


    private State state;

    private void Awake()
    {
        state = State.Active;
    }
    // Start is called before the first frame update
    private void Start()
    {
        //colliderTrigger.OnPlayerEnterTrigger += ColliderTrigger_OnPlayerEnterTrigger;
        audSrc = GameObject.Find("BellSoundHolder").GetComponent<AudioSource>();
        
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

                foreach (EnemyGroup group in enemyGroups)
                {
                    group.Update();
                }

                TestBattleOver();
                break;
        }
    }
    private void TestBattleOver()
    {
       if (state == State.Active)
        {
            if (IsWaveOver())
            {
                // Battle is over!
                state = State.BattleOver;
                audSrc.PlayOneShot(bellSounds[Random.Range(0, bellSounds.Length)]);

                Debug.Log("Battle is Over!"); //trigger next cross spawn 

                // wave is over
                nextCross.active = true;
            }
        }
    }
    private bool IsWaveOver()
    {
        foreach (EnemyGroup group in enemyGroups)
        {
            if (group.IsGroupDead())
            {
                // wave is over
               // nextCross.active = true;
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
    private class EnemyGroup
    {
        [SerializeField] private Enemy[] enemySpawnArray;
        [SerializeField] private float timer;

        public void Update()
        {
            if (timer >= 0)
            {
              timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    SpawnEnemies();
                }
            }
        }
        private void SpawnEnemies()
        {
            foreach (Enemy enemySpawn in enemySpawnArray)
            {
                enemySpawn.Spawn();
            }
        }
        // logic for testing to see if the wave is over
        public bool IsGroupDead()
        {
            if (timer < 0)
            {
                // wave spawned
                foreach (Enemy enemySpawn in enemySpawnArray)
                {
                    if (enemySpawn.isAlive)
                    {
                        return false;
                    }
                }
                Debug.Log("Wave is defetead");
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
