using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    public float spawnRate = 1;

    void Start()
    {
        InvokeRepeating("Spawn", spawnRate, spawnRate);
    }

    void Spawn() 
    {
        Instantiate(cubePrefab, transform.position, transform.rotation, transform);
    }
}
