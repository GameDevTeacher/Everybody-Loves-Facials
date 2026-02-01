using Enemy;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    public SpriteRenderer[] eyeSprites;

    private EnemyController _enemyController;
    public int eyesTaken;

    private void Start()
    {
        _enemyController = GetComponentInParent<EnemyController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_enemyController.isFullyCreamed) return;
        
        
        if (other.CompareTag("CreamProjectile"))
        {
            if (_enemyController.isFullyCreamed) return;
            _enemyController.creamCounter += 0.5f;
            print("Thanks for the cream Paddy: " + other.name);
            StartCoroutine(_enemyController.OnIsBeingCreamed());
            Destroy(other.gameObject);
        }
        
        if (_enemyController.creamLevel == EnemyController.CreamLevel.NoCream) return;
        
        if (other.CompareTag("FruitableProjectile"))
        {
            other.TryGetComponent(out SpriteRenderer sprite);

            for (var index = 0; index < eyeSprites.Length; index++)
            {
                var spr = eyeSprites[index];
                
                if (spr.sprite == null)
                {
                    spr.sprite = sprite.sprite;
                    eyesTaken++;
                    if (eyesTaken >= 2)
                    {
                        _enemyController.isFullyCreamed = true;
                    }
                    break;
                }
            }
            StopCoroutine(_enemyController.OnIsBeingCreamed());
            Destroy(other.gameObject);
        }

    }
}
