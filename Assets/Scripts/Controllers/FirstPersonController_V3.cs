using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController_V3 : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float movementSpeed = 5.0f;
    [SerializeField] KeyCode interactKey = KeyCode.E;

    [Header("Camera")]
    [SerializeField] float mouseSensitivity = 5.0f;
    [SerializeField] float clampAngleUp = -30.0f;
    [SerializeField] float clampAngleDown = 30.0f;
    
    private Rigidbody rb;
    private Camera playerCamera;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera = GetComponentInChildren<Camera>();

        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * vertical + transform.right * horizontal;
        movement = movement.normalized * movementSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationY += mouseX;
        rotationX -= mouseY;

        rotationX = Mathf.Clamp(rotationX, clampAngleUp, clampAngleDown);

        Quaternion localRotation = Quaternion.Euler(rotationX, 0, 0) * Quaternion.Euler(0, rotationY, 0);
        transform.localRotation = localRotation;

        //transform.eulerAngles = new Vector3(rotationX, rotationY, 0);

        bool interact = Input.GetKeyDown(interactKey);

        if (interact)
        {
            RaycastHit hit;

            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 2.0f))
            {
                InteractableObject obj = hit.collider.GetComponent<InteractableObject>();

                if (obj != null)
                {
                    obj.Interact();
                }
            }
        }
    }
}
