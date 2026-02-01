using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class FruitableAmmo : MonoBehaviour
{
    public int ammo = 4;
    public Sprite[] fruitableSprites;
    
    private SpriteRenderer _spriteRenderer;
    private Transform _target;
    [HideInInspector]public Fruitable fruitable;
    public SpawnController parentSpawn;


    private void Awake()
    {
        tag = "Fruitable";
    }

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        fruitable = GetComponent<Fruitable>();
        //fruitable.type = (Fruitable.Type)Random.Range(0, Enum.GetValues(typeof(Fruitable.Type)).Length);
        _spriteRenderer.sprite = fruitableSprites[(int)fruitable.type];
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
