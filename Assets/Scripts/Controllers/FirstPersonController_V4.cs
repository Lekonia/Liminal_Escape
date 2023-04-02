using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController_V4 : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float movementSpeed = 5.0f;

    [Header("Camera")]
    [SerializeField] float mouseSensitivity = 5.0f;
    [SerializeField] float clampAngleUp = -30.0f;
    [SerializeField] float clampAngleDown = 30.0f;

    private Rigidbody rb;
    private Camera playerCamera;

    private float rotationX = 0f;
    private float rotationY = 0f;

    private void Start()
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

    private void Update()
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

        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.eulerAngles = new Vector3(0, rotationY, 0);
    }
}
