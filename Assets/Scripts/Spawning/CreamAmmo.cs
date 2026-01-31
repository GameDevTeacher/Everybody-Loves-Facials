using UnityEngine;

public class CreamAmmo : MonoBehaviour
{
    public int ammo = 3;
    public Sprite[] creamSprites;

    private SpriteRenderer _spriteRenderer;
    private Transform _target;
    [HideInInspector] public Cream cream;
    

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        cream = GetComponent<Cream>();
        
        _spriteRenderer.sprite = creamSprites[(int)cream.type];
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        transform.LookAt(_target);
    }
}