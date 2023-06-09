using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float speedV = 0.0f;
    [SerializeField] float speedH = 0.0f;
    [SerializeField] float clampAngleUp = 0.0f;
    [SerializeField] float clampAngleDown = 0.0f;

    [SerializeField] bool drawGizmo = false;
    [SerializeField] float rayCastDistance = 2.0f;
    [SerializeField] float fieldOfView = 60.0f;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    void Update()
    {
        rotationY += speedV * Input.GetAxis("Mouse X");
        rotationX -= speedH * Input.GetAxis("Mouse Y");

        rotationX = Mathf.Clamp(rotationX, clampAngleUp, clampAngleDown);

        transform.eulerAngles = new Vector3(rotationX, rotationY, 0);
    }

    void OnDrawGizmos()
    {
        if (drawGizmo)
        {
            Vector3 frontRayPoint = transform.position + transform.forward * rayCastDistance;
            Vector3 leftRayPoint = transform.position + Quaternion.Euler(0, -fieldOfView * 0.5f, 0) * transform.forward * rayCastDistance;
            Vector3 rightRayPoint = transform.position + Quaternion.Euler(0, fieldOfView * 0.5f, 0) * transform.forward * rayCastDistance;

            Gizmos.color = Color.cyan;

            Gizmos.DrawRay(transform.position, transform.forward * rayCastDistance);
            Gizmos.DrawRay(transform.position, Quaternion.Euler(0, -fieldOfView * 0.5f, 0) * transform.forward * rayCastDistance);
            Gizmos.DrawRay(transform.position, Quaternion.Euler(0, fieldOfView * 0.5f, 0) * transform.forward * rayCastDistance);

            Gizmos.DrawLine(frontRayPoint, leftRayPoint);
            Gizmos.DrawLine(frontRayPoint, rightRayPoint);
        }
    }
}
