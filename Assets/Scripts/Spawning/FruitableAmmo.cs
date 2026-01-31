using UnityEngine;

public class FruitableAmmo : MonoBehaviour
{
    public int ammo = 3;
    public Sprite[] fruitableSprites;
    
    private SpriteRenderer _spriteRenderer;
    private Transform _target;
    [HideInInspector]public Fruitable fruitable;
    
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        fruitable = GetComponent<Fruitable>();
        _spriteRenderer.sprite = fruitableSprites[(int)fruitable.type];
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        transform.LookAt(_target);
    }
}
