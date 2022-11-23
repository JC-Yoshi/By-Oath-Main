using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]

    Transform destination;//defines the destination

    NavMeshAgent navMeshAgent;//defines the navmesh agent


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();

        if (navMeshAgent == null)
        {
            Debug.Log("No connected navmesh to" + gameObject.name);//gives a debug log if there isnt a neve mesh 
        }
        else
        {
            SetDestination();//runs the method
        }


    }

    private void SetDestination()//this sets the destination for the agent 
    {
        if (destination != null)
        {
            Vector3 targetVector = destination.transform.position;//finds the destinations location and sets = to target vector
            if (navMeshAgent.isOnNavMesh)
            {
                navMeshAgent.SetDestination(targetVector);  //makes the navMesh agents target = to the traget vector
            }
            else
            {
                Debug.Log("ERROR:  Agent is not on Nav Mesh!");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetDestination();
    }
}
