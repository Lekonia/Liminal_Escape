using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController_V2 : MonoBehaviour
{
    // Variables for movement and interaction
    public float movementSpeed = 5.0f;
    public float mouseSensitivity = 5.0f;
    public KeyCode interactKey = KeyCode.E;

    private Camera playerCamera;
    private Rigidbody rb;

    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }

        // Lock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Get input for movement and interaction
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool interact = Input.GetKeyDown(interactKey);

        // Move the player
        Vector3 movement = transform.forward * vertical + transform.right * horizontal;
        movement = movement.normalized * movementSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

        // Raycast to detect and interact with objects
        if (interact)
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 2.0f))
            {
                // Check if the object can be interacted
                InteractableObject obj = hit.collider.GetComponent<InteractableObject>();
                if (obj != null)
                {
                    obj.Interact();
                }
            }
        }
    }
}
