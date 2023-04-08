using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChangeTrigger : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float thresholdAngle = 60f;
    [SerializeField] private float maxRayCastDistance = 10f;
    [SerializeField] private Color notLookingColour = Color.cyan;
    [SerializeField] private Color lookingColour = Color.green;

    private float lastAngle = 0f;
    private Renderer objectRenderer;

    private void Awake()
    {
        objectRenderer = GetComponent<Renderer>();

        if (objectRenderer == null)
        {
            objectRenderer = gameObject.AddComponent<MeshRenderer>();
        }
    }

    private void Update()
    {
        float angle = Vector3.Angle(player.forward, transform.forward);

        if (angle > thresholdAngle && lastAngle <= thresholdAngle)
        {
            Debug.Log($"Player turned away from {gameObject.name}!");
        }

        lastAngle = angle;

        RaycastHit hit;

        if (Physics.Raycast(player.position, player.forward, out hit, maxRayCastDistance))
        {
            if (hit.collider.gameObject == gameObject)
            {
                objectRenderer.material.color = lookingColour;
                Debug.Log($"Player is looking at {hit.collider.gameObject.name}.");
            }

            else
            {
                objectRenderer.material.color = notLookingColour;
                Debug.Log("Not looking");
            }
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireSphere(Vector3.zero, maxRayCastDistance);
        Gizmos.DrawLine(Vector3.zero, Quaternion.Euler(0f, 0f, thresholdAngle) * Vector3.forward * maxRayCastDistance);
        Gizmos.DrawLine(Vector3.zero, Quaternion.Euler(0f, 0f, -thresholdAngle) * Vector3.forward * maxRayCastDistance);
    }
}
