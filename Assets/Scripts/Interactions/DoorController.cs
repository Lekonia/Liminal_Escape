using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] bool isOpen = false;
    [SerializeField] Animator anim;

    bool isAnimating = false;

    public void Interact()
    {
        if (isAnimating)
        {
            Debug.Log("Door is currently animating. Interaction ignored.");
            return;
        }

        isAnimating = true;

        if (isOpen)
        {
            Debug.Log("Door is now open");
            isOpen = true;

            // Set CanCloseDoor parameter to true so player can close the door
            anim.SetBool("CanCloseDoor", false);
            Debug.Log("CanCloseDoor set to false");
            anim.Play("OpenDoor");
        }

        else
        {
            Debug.Log("Door is now open");
            isOpen = false;

            //Set CanCloseDoor parameter to true so player can close the door
            anim.SetBool("CanCloseDoor", true);
            anim.Play("CloseDoor");
        }
    }

    public void AnimationFinished()
    {
        Debug.Log("Door animation finished.");
        isAnimating = false;
    }
}
