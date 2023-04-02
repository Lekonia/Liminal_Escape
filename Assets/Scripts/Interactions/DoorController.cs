using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float openAngle = 90.0f;
    public float closeAngle = 0.0f;
    public float smooth = 2.0f;
    public bool isOpen = false;

    public void OpenDoor()
    {
        isOpen = true;
    }

    public void CloseDoor()
    {
        isOpen = false;
    }

    private void Update()
    {
        float targetAngle = isOpen ? openAngle : closeAngle;
        Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
    }
}
