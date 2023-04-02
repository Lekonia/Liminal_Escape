using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] float interactRange = 3.0f;
    [SerializeField] bool showGizmos = true;
    [SerializeField] bool isDoor = false;
    [SerializeField] bool isOpen = false;

    private FirstPersonController_V4 playerController;

    private void Start()
    {
        // Get the FirstPersonController_V4 component from the player game object
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController_V4>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Get the player's position and check if they are within the interact range of this object
            Vector3 playerPos = playerController.transform.position;
            float distance = Vector3.Distance(playerPos, transform.position);

            if (distance <= interactRange)
            {
                Interact();
            }
        }
    }

    public void Interact()
    {
        Debug.Log("Object has been interacted!");

        // If this object is a door, toggle its open state
        if (!isDoor)
        {
            isOpen = !isOpen;
            Debug.Log("Door is now " + (isOpen ? "open" : "closed"));
            // Add code here to open or close the door visually/or physically
        }
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
