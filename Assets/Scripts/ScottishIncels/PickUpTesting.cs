using UnityEngine;

public class PickUpTesting : MonoBehaviour
{
    private Cream _playerCream;
    private Fruitable _playerFruitable;

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

            _playerFruitable.type = fruitable.type;
        }


        if (other.CompareTag("Cream"))
        {
            other.TryGetComponent(out Cream cream);
            _playerCream.type = cream.type;
        }
    }
}
