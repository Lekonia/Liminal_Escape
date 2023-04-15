using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTrigger : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabsToActivate;
    [SerializeField] private List<GameObject> prefabsToDeactivate;

    private bool isPlayerInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            ActivatePrefabs();
            DeactivatePrefabs();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside=false;
            DeactivatePrefabs();
        }
    }

    private void ActivatePrefabs()
    {
        foreach (GameObject prefab in prefabsToActivate)
        {
            prefab.SetActive(isPlayerInside);
        }
    }

    private void DeactivatePrefabs()
    {
        foreach (GameObject prefab in prefabsToDeactivate)
        {
            prefab.SetActive(!isPlayerInside);
        }
    }
}
