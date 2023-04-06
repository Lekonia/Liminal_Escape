using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This MouseLook class will allow the GameObject to look in mouse direction
 * 
 */

public class MouseLook : MonoBehaviour
{

    public float m_sensitivity = 100f; // mouse sensitivity
    public float m_clampAngle = 90f; // This limits our look up rotation
    public Transform m_playerObject; // Store the player container
    public Transform m_camera; // Store the camera transform

    private Vector2 m_mousePos; // Store mouse position
    private float m_xRotation = 0f; // Final loop up rotation value

    // Awake happens before Start
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock our cursor to the center of screen
    }


    // Update is called once per frame
    void Update()
    {
        GetMousePos(); // get the mouse position
        ClampUpRotation(); // clamp the lookup
        LookAt(); // look at mouse position
    }

    // Get mouse position
    private void GetMousePos()
    {
        m_mousePos.x = Input.GetAxis("Mouse X") * m_sensitivity *Time.deltaTime;
        m_mousePos.y = Input.GetAxis("Mouse Y") * m_sensitivity *Time.deltaTime;

        Debug.Log(m_mousePos);
    }

    // FixXRotation - means that we can clamp our look up function
    private void ClampUpRotation()
    {
        m_xRotation -= m_mousePos.y;
        m_xRotation = Mathf.Clamp(m_xRotation, -m_clampAngle, m_clampAngle);
    }

    // Look at mouse pos
    private void LookAt()
    {
        m_camera.transform.localRotation = Quaternion.Euler(m_xRotation, 0f, 0f); // Personal note: This functioned without the added 'f' after the '0' value and also worked with the 'f' need to revise why and its consequnces UPDATE: it has something to do with returning a float or being a float, or a rootbeer float
        m_playerObject.Rotate(Vector3.up * m_mousePos.x);
    }
}
