using UnityEngine;
using Player;

public class PickUpTesting : MonoBehaviour
{
    private Cream _playerCream;
    private Fruitable _playerFruitable;
    private PlayerAttack _playerAttack;
    
    public Sprite[] creamGunType;
    public Sprite[] fruitableSliceType;

    public SpriteRenderer creamGunRenderer;
    public SpriteRenderer fruitableRenderer;

    [SerializeField] private Weapon creamWeapon, fruitableWeapon;
    

    private void Start()
    {
        _playerCream = GetComponent<Cream>();
        _playerFruitable = GetComponent<Fruitable>();
        _playerAttack = GetComponent<PlayerAttack>();
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

            switch (_playerFruitable.type)
            {
                case Fruitable.Type.Cucumber:
                    fruitableRenderer.sprite = fruitableSliceType[0];
                    break;
                case Fruitable.Type.Eggplant:
                    fruitableRenderer.sprite = fruitableSliceType[1];
                    break;
                case Fruitable.Type.Orange:
                    fruitableRenderer.sprite = fruitableSliceType[2];
                    break;
                case Fruitable.Type.Lemon:
                    fruitableRenderer.sprite = fruitableSliceType[3];
                    break;
            }

            fruitableWeapon.Reload(fruitableAmmo.ammo);
            
            fruitableAmmo.ResetSpawn();
            Destroy(other.gameObject);
        }


        if (other.CompareTag("Cream"))
        {
            other.TryGetComponent(out Cream cream);
            other.TryGetComponent(out CreamAmmo creamAmmo);
            
            _playerCream.type = cream.type;

            switch (_playerCream.type)
            {
                case Cream.Type.Natural:
                    creamGunRenderer.sprite = creamGunType[0];
                    break;
                case Cream.Type.LabMade:
                    creamGunRenderer.sprite = creamGunType[1];
                    break;
                case Cream.Type.AloeVera:
                    creamGunRenderer.sprite = creamGunType[2];
                    break;
                case Cream.Type.HimalayanPinkSalt:
                    creamGunRenderer.sprite = creamGunType[3];
                    break;
            }
            
            creamWeapon.Reload(creamAmmo.ammo);
            
            creamAmmo.ResetSpawn();
            Destroy(other.gameObject);
        }
    }
}
