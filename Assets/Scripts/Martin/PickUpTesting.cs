using UnityEngine;

public class PickUpTesting : MonoBehaviour
{
    private Cream _playerCream;
    private Fruitable _playerFruitable;

    public Sprite[] creamGunType;
    public Sprite[] fruitableSliceType;

    public SpriteRenderer creamGunRenderer;
    public SpriteRenderer fruitableRenderer;

    private void Start()
    {
        _playerCream = GetComponent<Cream>();
        _playerFruitable = GetComponent<Fruitable>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fruitable"))
        {
            // essentially, if the player collides with a fruitable, get a fruitable component from
            // the object, switch case, change weapon, beep boop.
            other.TryGetComponent(out Fruitable fruitable);
            other.TryGetComponent(out FruitableAmmo fruitableAmmo);
            
            _playerFruitable.type = fruitable.type;
            
            fruitableAmmo.ResetSpawn();
            Destroy(other.gameObject);
        }


        if (other.CompareTag("Cream"))
        {
            other.TryGetComponent(out Cream cream);
            other.TryGetComponent(out CreamAmmo creamAmmo);
            
            _playerCream.type = cream.type;
            creamAmmo.ResetSpawn();
            Destroy(other.gameObject);
        }
    }
}
