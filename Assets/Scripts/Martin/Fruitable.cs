using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Fruitable : MonoBehaviour
{
    // this script can be used for the pickups and the player... maybe?
    
    public enum Type
    {
        Cucumber,
        Eggplant,
        Orange,
        Lemon
    }
    
    public Type type;
    
    private void Awake()
    {
        var values = Enum.GetValues(typeof(Type));
        var rand = Random.Range(0, values.Length);
        Type randomType = (Type)values.GetValue(rand);
        type = randomType;
    }
}
