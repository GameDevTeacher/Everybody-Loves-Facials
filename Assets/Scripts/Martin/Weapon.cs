using System;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    // This script is an all-rounder, works for both cream and fruitable.

    public enum WeaponType
    {
        Cream,
        Fruitable
    }
    
    public WeaponType currentType;
    
    [Header("Projectile")]
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed;
    
    [Header("Firing")]
    [SerializeField] private float currentAmmo;
    [SerializeField] private float maxAmmo;
    [SerializeField] private float fireRate = 0.3f;
    private float _fireRateCounter;

    [Header("References")] 
    [SerializeField] private Camera cam;
    [SerializeField] private Cream playerCream;
    [SerializeField] private Fruitable playerFruitable;
    [SerializeField] private Sprite[] fruitableSprites;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI ammoText;

    private void OnEnable()
    {
        ammoText.gameObject.SetActive(true);
        ammoText.text = currentType + ": " + currentAmmo;
    }

    private void OnDisable()
    {
        if (ammoText != null)
        {
            ammoText.gameObject.SetActive(false);
        }
    }

    public void UpdateCream(bool shoot)
    {
        if (!shoot || !(currentAmmo > 0) || !(_fireRateCounter < Time.time)) return;
        
        var projectileClone = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        Destroy(projectileClone, 5f);
            
        projectileClone.TryGetComponent(out Rigidbody rigidBody);
        rigidBody.linearVelocity = GetMoveDirection() * projectileSpeed;
        
        projectileClone.TryGetComponent(out Cream cream);
        cream.type = playerCream.type;
        
        currentAmmo--;
        
        ammoText.text = currentType + ": " + currentAmmo;
        
        _fireRateCounter = Time.time + fireRate;
    }

    public void UpdateFruitable(bool shoot)
    {
        if (!shoot || !(currentAmmo > 0) || !(_fireRateCounter < Time.time)) return;
        
        var projectileClone = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        Destroy(projectileClone, 5f);
            
        projectileClone.TryGetComponent(out Rigidbody rigidBody);
        rigidBody.linearVelocity = GetMoveDirection() * projectileSpeed;
        
        projectileClone.TryGetComponent(out Fruitable fruitable);
        fruitable.type = playerFruitable.type;
        
        projectileClone.TryGetComponent(out SpriteRenderer spriteRenderer);

        switch (fruitable.type)
        {
            case Fruitable.Type.Cucumber:
                spriteRenderer.sprite = fruitableSprites[0];
                break;
            case Fruitable.Type.Eggplant:
                spriteRenderer.sprite = fruitableSprites[1];
                break;
            case Fruitable.Type.Orange:
                spriteRenderer.sprite = fruitableSprites[2];
                break;
            case Fruitable.Type.Lemon:
                spriteRenderer.sprite = fruitableSprites[3];
                break;
        }
        
        currentAmmo--;
        
        ammoText.text = currentType + ": " + currentAmmo;
        
        _fireRateCounter = Time.time + fireRate;
    }
    
    private Vector3 GetMoveDirection()
    {
        float x = Screen.width / 2;
        float y = Screen.height / 2;

        var ray = cam.ScreenPointToRay(new Vector2(x, y));
        return ray.direction;
    }

    public void Reload(float reloadAmmo)
    {
        currentAmmo = reloadAmmo;
        ammoText.text = currentType + ": " + currentAmmo;
    }
}
