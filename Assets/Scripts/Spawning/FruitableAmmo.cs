using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class FruitableAmmo : MonoBehaviour
{
    public int ammo = 3;
    public Types type;
    public Sprite[] fruitableSprites;

    private SpriteRenderer _spriteRenderer;
    private Transform _target;
    
    public enum Types
    {
        Cucumber,
        Eggplant,
        Orange,
        Lemon
    }
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        type = (Types)Random.Range(0, Enum.GetValues(typeof(Types)).Length);
        _spriteRenderer.sprite = fruitableSprites[(int)type];
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        transform.LookAt(_target);
    }
}
