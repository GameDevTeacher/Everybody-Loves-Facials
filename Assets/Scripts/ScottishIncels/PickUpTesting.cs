using System;
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

            switch (fruitable.type)
            {
                case Fruitable.Type.Cucumber:
                    print("Cucumber");
                    _playerFruitable.type = Fruitable.Type.Cucumber;
                    break;
                case Fruitable.Type.Eggplant:
                    print("Eggplant");
                    _playerFruitable.type = Fruitable.Type.Eggplant;
                    break;
                case Fruitable.Type.Orange:
                    print("Orange");
                    _playerFruitable.type = Fruitable.Type.Orange;
                    break;
                case Fruitable.Type.Apple:
                    print("Apple");
                    _playerFruitable.type = Fruitable.Type.Apple;
                    break;
                case Fruitable.Type.Potato:
                    print("Potato");
                    _playerFruitable.type = Fruitable.Type.Potato;
                    break;
                case Fruitable.Type.Broccoli:
                    print("Broccoli");
                    _playerFruitable.type = Fruitable.Type.Broccoli;
                    break;
                case Fruitable.Type.Lemon:
                    print("Lemon");
                    _playerFruitable.type = Fruitable.Type.Lemon;
                    break;
            }
        }

        if (other.CompareTag("Cream"))
        {
            other.TryGetComponent(out Cream cream);

            switch (cream.type)
            {
                case Cream.Type.Natural:
                    print("Natural");
                    _playerCream.type = Cream.Type.Natural;
                    break;
                case Cream.Type.LabMade:
                    print("Lab Made");
                    _playerCream.type = Cream.Type.LabMade;
                    break;
                case Cream.Type.AloeVera:
                    print("Aloe Vera");
                    _playerCream.type = Cream.Type.AloeVera;
                    break;
                case Cream.Type.HimalayanPinkSalt:
                    print("Himalayan Pink Salt");
                    _playerCream.type = Cream.Type.HimalayanPinkSalt;
                    break;
            }
        }
    }
}
