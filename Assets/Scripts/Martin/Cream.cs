using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cream : MonoBehaviour
{
    // this script can be used for the pickups and the player... maybe?
    
    public enum Type
    {
        Natural,
        LabMade,
        AloeVera,
        HimalayanPinkSalt
    }
    
    public Type type;

    private void Awake()
    {
        if (transform.CompareTag("FruitableProjectile") || transform.CompareTag("CreamProjectile")) return;
        
        var values = Enum.GetValues(typeof(Type));
        var rand = Random.Range(0, values.Length);
        Type randomType = (Type)values.GetValue(rand);
        type = randomType;
    }
}
