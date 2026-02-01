using System;
using Enemy;
using UnityEngine;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        // This script ensures that the player can fire their weapon.
        
        [SerializeField] private Transform weaponHolder;
        [SerializeField] public Transform[] weapons;

        private void Start()
        {
            weapons = new Transform[weaponHolder.childCount];

            for (int i = 0; i < weaponHolder.childCount; i++)
            {
                weapons[i] = weaponHolder.GetChild(i);
            }
        }

        public void UpdateShooting(bool shoot)
        {
            // from here, we call UpdateProjectile() from the weapon script, which is attached to every single weapon
            Weapon currentWeapon = GetCurrentChild();

            switch (currentWeapon.currentType)
            {
                case Weapon.WeaponType.Cream:
                    currentWeapon.UpdateCream(shoot);
                    break;
                case Weapon.WeaponType.Fruitable:
                    currentWeapon.UpdateFruitable(shoot);
                    break;
            }
        }

        public Weapon GetCurrentChild()
        {
            foreach (var weapon in weapons)
            {
                if (weapon.gameObject.activeSelf)
                {
                    weapon.TryGetComponent(out Weapon current);
                    return current;
                }
            }
            return null;
        }
    }
}