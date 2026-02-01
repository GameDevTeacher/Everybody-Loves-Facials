using UnityEngine;

public class Eyes : MonoBehaviour
{
    public SpriteRenderer[] eyeSprites;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fruitable"))
        {
            other.TryGetComponent(out SpriteRenderer sprite);
            
            foreach (SpriteRenderer spr in eyeSprites)
            {
                if (spr.sprite != null)
                {
                    spr.sprite = sprite.sprite;
                }
                print("already taken!");

                break;
            }
        }
    }
}
