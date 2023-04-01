using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    // Variables for movement and interaction
    public float movementSpeed = 5.0f;
    public float mouseSensitivity = 5.0f;
    public KeyCode interactKey = KeyCode.E;

    /*
     * Going to experiment with some camera clamping here
     */

    // Variables for camera clamping
    //public Transform cameraTransform;
    //public float maxLookUpAngle = 80f;
    //public float maxLookDownAngle = -80f;

    /*
     * New Clamp camera stuff
     */

    //[SerializeField] float minRotation = -80f;
    //[SerializeField] float maxRotation = 80f;

    /*
     * The reason i had a groundcheck was issues with the player falling over or disturbingly floating away,
     * this however is more likely due to approaching a slope and the game not having a navmesh agent, 
     * this needs more monitoring and possible fix. (Meanwhile; AVOID SLOPES!)
    */

    // Ground check
    //public float gravity = -9.81f;
    //public Transform groundCheck;
    //public float groundDistance = 0.4f;
    //public LayerMask groundMask;
    //bool isGrounded;

    //Vector3 velocity; // Not sure about this line but i am using it for ground checking

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
        // Ground function
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //if (isGrounded && velocity.y < 0)
        //{
        //    velocity.y = -2f;
        //}

        //velocity.y += gravity * Time.deltaTime;

        // Get input for movement and interaction
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        bool interact = Input.GetKeyDown(interactKey);

        // Rotate the camera with mouse input
        transform.Rotate(Vector3.up * mouseX * mouseSensitivity);
        playerCamera.transform.Rotate(Vector3.right * -mouseY * mouseSensitivity); // Changed this line to update on a clamp experiment

        /* 
         * Clamp rotation experiment here
         */

        //Get the rotation of the camera transform
        //Quaternion cameraRotation = cameraTransform.rotation;

        // Clamp the rotation around the x-axis (up and down)
        //Vector3 eulerAngles = cameraRotation.eulerAngles;
        //float xAngle = Mathf.Clamp(eulerAngles.x, maxLookDownAngle, maxLookUpAngle);
        //eulerAngles.x = xAngle;

        // Set the new rotation for the camera
        //cameraTransform.rotation = Quaternion.Euler(eulerAngles);

        /*
         * New camera clamp experiment, above was didnt quite work
         */

        //float verticalRotation = transform.localEulerAngles.x; // Get the current vertical rotation angle of the camera

        // Clamp the vertical rotation angle to the specified range
        //verticalRotation = Mathf.Clamp(verticalRotation, minRotation, maxRotation);

        // Apply the clamped rotation to the camera
        //transform.localEulerAngles = new Vector3(verticalRotation, transform.localEulerAngles.y, transform.localEulerAngles.z);

        /*
         * New new experiment!
         * Do not worry, all of this miss will be gone when the game is being made proper after the prototype/experiment stage
         * or someone else does it for me, lol! but also, much appreciated!
         */

        // Clamp the rotation of the camera around the x-axis (up and down)
        //Vector3 cameraRotation = cameraTransform.localEulerAngles;
        //float xAngle = cameraRotation.x - mouseY * mouseSensitivity;
        //xAngle = Mathf.Clamp(xAngle, maxLookDownAngle, maxLookUpAngle);
        //cameraRotation.x = xAngle;
        //cameraTransform.localEulerAngles = cameraRotation;

        /*
         * FORGET EVERYTHING V2 EXISTS AND WORKS... for now
         */

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
