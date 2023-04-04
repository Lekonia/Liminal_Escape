using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController_V2 : MonoBehaviour
{
    [SerializeField] private bool isOpen = false;
    [SerializeField] private Animator animator;

    private void Start()
    {
        // Set intial state of the door
        animator.SetBool("isOpen", isOpen);
    }

    public void Interact()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            // Door is currently animating, ignore interaction
            Debug.Log("Door is currently animating, interaction ignored.");
            return;
        }

        // Toggle the state of the door
        isOpen = !isOpen;

        // Update the animator
        animator.SetBool("isOpen", isOpen);

        if (isOpen)
        {
            Debug.Log("Door is now open.");
        }

        else
        {
            Debug.Log("Door is now closed.");
        }
    }
}

/*
 * TRANSITIONS GUIDE:
 * 
 * The Animator Controller should have 3 states: Idle, OpenDoor and CloseDoor.
 * 
 * From Idle to OpenDoor:
 *  - Add a transition from Idle to OpenDoor
 *  - Set the condition to trigger the transition (e.g. Interact trigger)
 *  - Set the transition duration
 *  - Set the exit time to 1 (so the animation completes before exiting the state)
 * 
 * From OpenDoor to CloseDoor:
 *  - Add a transition from OpenDoor to CloseDoor
 *  - Set the condition to trigger the transition (e.g. isOpen parameter equals true)
 *  - Set the transition duration
 * 
 * From CloseDoor to Idle:
 *  - Add a transition from CloseDoor to Idle
 *  - Set the condition to trigger the transition (e.g. animation complete trigger)
 *  - Set the transition duration
 */
