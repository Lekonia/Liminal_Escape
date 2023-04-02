using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoTool : MonoBehaviour
{
    [Header("Gizmo On/Off")]
    [SerializeField] bool showGizmo = true;

    [Header("Needed Scripts")]
    public FirstPersonController_V4 firstPersonController;
    private float distance;

    [Header("Gizmo Colour")]
    [SerializeField] Color gizmoColour = Color.red;
    [SerializeField] Color hitColour = Color.green;

    [Header("Hit Sphere Size")]
    [SerializeField] float hitSphereSize = 0.1f;

    private void OnDrawGizmos()
    {
        if (!showGizmo)
        {
            return;
        }

        distance = firstPersonController.interactDistance;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, distance))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                Gizmos.color = hitColour;
                Gizmos.DrawLine(transform.position, hit.point);
                Gizmos.DrawWireSphere(hit.point, hitSphereSize);
                return;
            }
        }

        Gizmos.color = gizmoColour;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * distance);
        Gizmos.DrawWireSphere(transform.position + transform.forward * distance, hitSphereSize);
    }
}
