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
        _spawnTimeCounter = Time.time + Random.Range(0, spawnTime);
    }

    private void Update()
    {
        if (Time.time < _spawnTimeCounter) return;
        if (currentSpawnedObject != null) return;
            var clone = Instantiate(spawnableObjects[Random.Range(0, spawnableObjects.Length)], spawnPoint.position, Quaternion.identity);

            if (clone.CompareTag("Fruitable"))
            {
                clone.TryGetComponent(out FruitableAmmo fruitableAmmo);
                fruitableAmmo.parentSpawn = this;
            }
            else if (clone.CompareTag("Cream"))
            {
                clone.TryGetComponent(out CreamAmmo creamAmmo);
                creamAmmo.parentSpawn = this;
            }
            currentSpawnedObject = clone;

        
    }

    public void SetTimer()
    {
        _spawnTimeCounter = Time.time + spawnTime;
    }
}