using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabActivation : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float detectionDistance = 10f;
    [SerializeField] private List<GameObject> prefabs;
    [SerializeField] private List<bool> prefabActivation;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireSphere(Vector3.zero, detectionDistance);
    }

    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(player.position, player.forward, out hit, detectionDistance))
        {
            if (hit.collider.gameObject == gameObject)
            {
                Debug.Log("Player is looking at the object!");

                for (int i = 0; i < prefabs.Count; i++)
                {
                    if (prefabActivation[i])
                    {
                        prefabs[i].SetActive(true);
                        Debug.Log($"Activated {prefabs[i].name}");
                    }

                    else
                    {
                        prefabs[i].SetActive(false);
                        Debug.Log($"Deactuvated {prefabs[i].name}");
                    }
                }
            }
        }
    }
}
