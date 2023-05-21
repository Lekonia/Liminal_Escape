using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hallway_Endless : MonoBehaviour
{
    public Transform playerT;
    public GameObject blocksPref;
    public float spawnZ = 0f;
    private float blockLen = 10f;
    private int nbrBlocksInScreen = 5;

    void Start()
    {
        for(int i = 0; i < nbrBlocksInScreen; i++)
        {
            SpawnBlocks();
        }
    }

    void Update()
    {
        if(playerT.position.z > spawnZ - (nbrBlocksInScreen * blockLen))
        {
            SpawnBlocks();
        }
    }

    private void SpawnBlocks()
    {
        GameObject go = Instantiate(blocksPref) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += blockLen;
    }
}
