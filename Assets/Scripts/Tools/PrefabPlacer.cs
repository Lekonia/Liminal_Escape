using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabPlacer : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private List<GameObject> spawnObjects;

    private List<KeyCode> spawnKeyCodes = new List<KeyCode>
    {
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5
    };

    private void Start()
    {
        if (spawnPoints.Count != spawnObjects.Count)
        {
            Debug.LogError("Number of spawn points does not match the number of prefabs to spawn.");
            return;
        }
    }

    private void Update()
    {
        // Loop through each spawn point and check for input to spawn a prefab
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            if (Input.GetKeyDown(spawnKeyCodes[i]))
            {
                SpawnPrefab(i);
            }
        }
    }

    private void SpawnPrefab(int index)
    {
        // Instantiate the prefab at the spawn point
        GameObject prefab = Instantiate(spawnObjects[index], spawnPoints[index].position, spawnPoints[index].rotation);

        // Set the parent of the prefab to the object this script is attached to
        prefab.transform.parent = transform;
    }
}
