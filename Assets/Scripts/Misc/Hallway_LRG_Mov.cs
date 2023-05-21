using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hallway_LRG_Mov : MonoBehaviour
{

    public float speed;
    public float spawnDistance;
    public GameObject objectPiece;

    private bool hasChild = false;

    void Update()
    {
        transform.Translate(-transform.forward * speed); // For my own edification, the - on the transform clearly defines the direction it will move, or at least one of the ways it will move.

        Vector3 m_pos = transform.position;
        if (m_pos.z <= 0 && !hasChild)
        {
            hasChild = true;
            Vector3 spawn_pos = new Vector3(0, 0, 0);
            spawn_pos.z = m_pos.z + spawnDistance;
            Instantiate(objectPiece, spawn_pos, Quaternion.identity);
        }

        if (m_pos.z < -10)
        {
            Destroy(gameObject);
        }
    }
}
