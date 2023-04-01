using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController_V2 : MonoBehaviour
{
    // Variables for movement and interaction
    [Header("Movement and Interaction")]
    public float movementSpeed = 5.0f;      // Movement speed of the player
    public float mouseSensitivity = 5.0f;   // Sensitivity of the mouse for rotating
    public KeyCode interactKey = KeyCode.E; // Key to use for interacting with objects

    // Camera Controller from another script being added here
    [SerializeField] float speedV = 0.0f;          // Vertical Speed of the camera
    [SerializeField] float speedH = 0.0f;          //
    [SerializeField] float clampAngleUp = -30.0f;  // Maximum angle that the camera can look up
    [SerializeField] float clampAngleDown = 30.0f; // Maximum angle that the camera can look down

    // This relates to the Gizmo function, used as a tool to see the angle of view of the player as an average
    // [SerializeField] float fieldOfView = 60.0f;

    // Private variables
    private Camera playerCamera; // Reference to the player camera
    private Rigidbody rb;        // Reference to the player's rigidbody

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    void Start()
    {
        // Get the player camera and rigidbody components
        playerCamera = GetComponentInChildren<Camera>();
        rb = GetComponent<Rigidbody>();

        // If there is no rigidbody, add one to the game object
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
        float horizontal = Input.GetAxis("Horizontal");             // Horizontal movement input
        float vertical = Input.GetAxis("Vertical");                 // Vertical movement input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity; // Mouse input for the horizontal rotation

        // Move the player
        Vector3 movement = transform.forward * vertical + transform.right * horizontal; // Calculate the move vector
        movement = movement.normalized * movementSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

        rotationY += speedV * Input.GetAxis("Mouse X");
        rotationX -= speedH * Input.GetAxis("Mouse Y");

        rotationX = Mathf.Clamp(rotationX, clampAngleUp, clampAngleDown);

        transform.eulerAngles = new Vector3(rotationX, rotationY, 0);

        // Rotate the player horizontally
        //float rotation = transform.localEulerAngles.y + mouseX;
        //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, rotation, 0);

        // Raycast to detect and interact with objects
        bool interact = Input.GetKeyDown(interactKey);

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
