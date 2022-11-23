using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interactor : MonoBehaviour
{
     public Transform interatctionPoint;
     public float interarctionPointRadius;
     public LayerMask interaractionLayerMask;

    private readonly Collider[] colliders = new Collider[6];//how many interactables are there 

     public int numFound;


    // Update is called once per frame
    void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(interatctionPoint.position, interarctionPointRadius, colliders, interaractionLayerMask);//detects any interactables in range


        if (numFound > 0)
        {
            var interactable = colliders[0].GetComponent<IInteractable>();// checks to see if the item can be interacted with   

            if (interactable != null && Input.GetKeyDown(KeyCode.E))//allows interact to work  by pressing E
            {
                interactable.Interact(this);//runs interact on this game object
            }
        }
    }

    private void OnDrawGizmos()//draws interactable range 
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(interatctionPoint.position, interarctionPointRadius);
    }
}
