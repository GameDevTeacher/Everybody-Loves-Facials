using UnityEngine;

public class Fruitable : MonoBehaviour
{
    // this script can be used for the pickups and the player... maybe?
    
    public enum Type
    {
        Cucumber,
        Eggplant,
        Orange,
        Apple,
        Potato,
        Broccoli,
        Lemon
    }
    
    public Type type;
}
