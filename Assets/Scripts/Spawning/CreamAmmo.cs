using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CreamAmmo : MonoBehaviour
{
    public int ammo = 3;
    public Types type;
    public Sprite[] creamSprites;

    private SpriteRenderer _spriteRenderer;
    private Transform _target;
    
    public enum Types
    {
        Natural,
        LabMade,
        AloeVera,
        HimalayanPinkSalt,
        NumberOfTypes
    }
        
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        type = (Types)Random.Range(0, Enum.GetValues(typeof(Types)).Length);
        _spriteRenderer.sprite = creamSprites[(int)type];
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        transform.LookAt(_target);
    }
}