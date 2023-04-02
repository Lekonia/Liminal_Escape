using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController_V4 : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float movementSpeed = 5.0f;

    [Header("Interaction")]
    [SerializeField] KeyCode interactKey = KeyCode.E;
    
    public float interactDistance = 2.0f;

    [Header("Camera")]
    [SerializeField] Transform cameraTransform;
    [SerializeField] float mouseSensitivity = 5.0f;
    [SerializeField] float clampAngleUp = -30.0f;
    [SerializeField] float clampAngleDown = 30.0f;

    private float rotationX = 0f;
    private float rotationY = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Move();
        Look();
        Interact();
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * vertical + transform.right * horizontal;
        movement = movement.normalized * movementSpeed * Time.deltaTime;
        transform.position += movement;
    }

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationY += mouseX;
        rotationX -= mouseY;

        rotationX = Mathf.Clamp(rotationX, clampAngleUp, clampAngleDown);

        cameraTransform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        transform.eulerAngles = new Vector3(0, rotationY, 0);
    }

    void Interact()
    {
        if (Input.GetKeyDown(interactKey))
        {
            RaycastHit hit;

            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, interactDistance))
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
