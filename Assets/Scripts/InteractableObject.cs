using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] float interactRange = 0.0f;

    [SerializeField] bool showGizmos = true;

    public void Interact()
    {
        Debug.Log("Object has been interacted!");

        // Interaction code here-ish
    }

    private void OnDrawGizmos()
    {
        if (!showGizmos)
            return;

        // Draws a wire sphere to show the CheckSphere area
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}
