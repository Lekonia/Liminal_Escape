using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infinite_Hallway : MonoBehaviour
{
    [SerializeField] GameObject hallwayPrefab;  // Reference to the hallway section prefab
    [SerializeField] Transform spawnPoint;      // Reference to the Spawn Pont object
    [SerializeField] Transform destroyPoint;    // Reference to the Destroy Point object
    [SerializeField] float spawnDistance = 10f; // Distance at which to spawn a new hallway section

    private GameObject currentHallway;          // Reference to the current hallway section

    private void Start()
    {
        // Spawn the first hallway section
        SpawnHallway();
    }

    private void Update() // This spawns alot of hallways and i dont think there really is a player check
    {
        // Check if the player has reached the Spawn Point
        if (Vector3.Distance(transform.position, spawnPoint.position) < spawnDistance)
        {
            // Spawn a new hallway section
            SpawnHallway();

            // Destroy the previous hallway section
            Destroy(currentHallway);
        }
    }

    private void SpawnHallway()
    {
        // Instantiate the hallway section prefab at the Spawn Point position
        currentHallway = Instantiate(hallwayPrefab, spawnPoint.position, Quaternion.identity);

        // Set the Spawn Point to the end of the new hallway section
        spawnPoint.position += currentHallway.GetComponentInChildren<HallwayEnd>().endPoint.position - currentHallway.GetComponentInChildren<HallwayEnd>().startPoint.position;
    }

    private void OnDrawGizmosSelected() // Future plan, change this method to be like the others, a bool to turn on or off the gizmos
    {
        // Draw a line between the Spawn Pont and Destroy Point for easier debugging
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(spawnPoint.position, destroyPoint.position);
    }
}
