using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendHallway : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject hallwayPrefab;

    [Header("Settings")]
    [SerializeField] private int numExtensions;
    [SerializeField] private Vector3 extensionDirection = Vector3.forward;
    [SerializeField] private float extensionDistance = 10f;

    [Header("Starting Pont")]
    [SerializeField] private Transform startingPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered ExtendHallway trigger.");

            Vector3 currentExtensionPosition = startingPoint.position;

            for (int i = 0; i < numExtensions; i++)
            {
                GameObject newHallway = Instantiate(hallwayPrefab, currentExtensionPosition, Quaternion.identity);
                Debug.Log($"Instatiated new hallway ({i + 1} of {numExtensions}).");

                Vector3 hallwaySize = newHallway.GetComponent<BoxCollider>().size;
                Vector3 extensionOffset = extensionDirection.normalized * (hallwaySize.z + extensionDistance);

                currentExtensionPosition += extensionOffset;
                Debug.Log($"Moved to new hallway position ({currentExtensionPosition}).");
            }
        }
    }
}

