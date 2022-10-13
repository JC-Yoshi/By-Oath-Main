using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interactor : MonoBehaviour
{
     public Transform interatctionPoint;
     public float interarctionPointRadius;
     public LayerMask interaractionLayerMask;

    private readonly Collider[] colliders = new Collider[6];

     public int numFound;


    // Update is called once per frame
    void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(interatctionPoint.position, interarctionPointRadius, colliders, interaractionLayerMask);


        if (numFound > 0)
        {
            var interactable = colliders[0].GetComponent<IInteractable>();  

            if (interactable != null && Input.GetKeyDown(KeyCode.E))
            {
                interactable.Interact(this);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(interatctionPoint.position, interarctionPointRadius);
    }
}
