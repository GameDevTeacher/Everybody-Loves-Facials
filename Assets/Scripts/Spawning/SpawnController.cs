using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnController : MonoBehaviour
{
    public GameObject[] spawnableObjects;
    public GameObject currentSpawnedObject;
    public Transform spawnPoint;
    public float spawnTime;
    private float _spawnTimeCounter;

    private void Start()
    {
        _spawnTimeCounter = Time.time + spawnTime;
    }

    private void Update()
    {
        if (Time.time < _spawnTimeCounter) return;
        if (currentSpawnedObject == null) return;

        var clone = Instantiate(spawnableObjects[Random.Range(0, spawnableObjects.Length)], spawnPoint.position, Quaternion.identity);
        currentSpawnedObject = clone;
    }
}