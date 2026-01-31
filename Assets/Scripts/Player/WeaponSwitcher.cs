using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSwitcher : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform[] weapons;
    
    [Header("Keys")]
    public Key[] keys;
    
    [Header("Settings")]
    [SerializeField] private float switchTime;

    private int _selectedWeapon;
    private float _timeSinceLastSwitch;

    private void Start()
    {
        SetWeapons();
        Select(_selectedWeapon);
        
        _timeSinceLastSwitch = 0f;
    }

    private void Update()
    {
        int previousSelectedWeapon = _selectedWeapon;

        for (int i = 0; i < keys.Length; i++)
        {
            if (Keyboard.current[keys[i]].wasPressedThisFrame && _timeSinceLastSwitch >= switchTime)
            {
                _selectedWeapon = i;
            }
        }
        
        if (previousSelectedWeapon != _selectedWeapon) Select(_selectedWeapon);
        
        _timeSinceLastSwitch += Time.deltaTime;
    }

    private void SetWeapons()
    {
        weapons = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            weapons[i] = transform.GetChild(i);
        }
        
        if (keys == null) keys = new Key[weapons.Length];
    }

    private void Select(int weaponIndex)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].gameObject.SetActive(i == weaponIndex);
        }

        _timeSinceLastSwitch = 0f;
        
        OnWeaponSelected();
    }

    private void OnWeaponSelected()
    {
        // here, we can play an animation
        print("Selected new weapon...");
    }
}
