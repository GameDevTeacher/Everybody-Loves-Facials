using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CreamAmmo : MonoBehaviour
{
    public int ammo = 2000;
    public Sprite[] creamSprites;

    private SpriteRenderer _spriteRenderer;
    private Transform _target;
    [HideInInspector] public Cream cream;
    public SpawnController parentSpawn;

    private void Awake()
    {
        tag = "Cream";
    }

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        cream = GetComponent<Cream>();
        //cream.type = (Cream.Type)Random.Range(0, Enum.GetValues(typeof(Cream.Type)).Length);
        _spriteRenderer.sprite = creamSprites[(int)cream.type];
        _target = GameObject.FindGameObjectWithTag("Player").transform;
       
    }

    private void Update()
    {
        transform.LookAt(_target);
    }

    public void ResetSpawn()
    {
        parentSpawn.SetTimer();
        parentSpawn.currentSpawnedObject = null;
    }
    
}