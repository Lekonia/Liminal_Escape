using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endless_Hallway_V4 : MonoBehaviour
{
    public GameObject[] hallwayPrefabs;

    private Transform playerTransform;
    [SerializeField] private float spawnZ = 0.0f;
    [SerializeField] private float hallwayLength = 12.0f;
    [SerializeField] private int numberOfHallwaysOnScreen = 7;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < numberOfHallwaysOnScreen; i++)
        {
            SpawnHallway();
        }
    }

    private void Update()
    {
        if (playerTransform.position.z > (spawnZ - numberOfHallwaysOnScreen * hallwayLength))
        {
            SpawnHallway();
        }
    }

    private void SpawnHallway(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(hallwayPrefabs[0]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += hallwayLength;
    }
}
