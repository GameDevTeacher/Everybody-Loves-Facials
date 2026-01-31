using UnityEngine;
using System.Collections.Generic;

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

    [Header("Deactivating")]
    public List<GameObject> objectsToDeactivate;
    private int currentIndex = 0;
    
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
        
        currentAmmo--;
        _fireRateCounter = Time.time + fireRate;
        DeactivateNextObject();
    }

    private void DeactivateNextObject()
    {
        if (objectsToDeactivate != null && currentIndex < objectsToDeactivate.Count)
        {
            if (objectsToDeactivate[currentIndex] != null)
            {
                objectsToDeactivate[currentIndex].SetActive(false);
                Debug.Log("Deactivated; " + objectsToDeactivate[currentIndex].name);
            }
        
            currentIndex++;
        }
        else
        {
            Debug.Log("No More Objects To Deactivate");
        }
    }
    
    private Vector3 GetMoveDirection()
    {
        float x = Screen.width / 2;
        float y = Screen.height / 2;

        var ray = cam.ScreenPointToRay(new Vector2(x, y));
        return ray.direction;
    }
}
