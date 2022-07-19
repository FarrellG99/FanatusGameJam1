using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public Transform target;
    public GameObject[] groundPrefabs;
    public float zSpawn = 0;
    public float tileLength = 100;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < groundPrefabs.Length; i++)
        {
            spawnGround(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target.position.z >= zSpawn - 100)
        {
            for (int i = 0; i < groundPrefabs.Length; i++)
            {
                spawnGround(i);
            }
        }
    }

    public void spawnGround(int groundIndex)
    {
        Instantiate(groundPrefabs[groundIndex], transform.forward * zSpawn, transform.rotation);
        zSpawn += tileLength;
    }
}
