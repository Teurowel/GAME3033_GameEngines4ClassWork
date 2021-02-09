using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Weapons
{
    public enum WeaponType
    {
        None,
        MachineGun,
        Pistol
    }

    [Serializable]
    public struct WeaponStats
    {
        public WeaponType WeaponType;
        public string Name;
        public float Damage;
        public int BulletsInClip;
        public int ClipSize;
        public int BulletsAvailable;
        public float FireStartDelay;
        public float FireRate;
        public float FireDistance;
        public bool Repeating;
        public LayerMask WeaponHitLayers;
    }

    public class WeaponComponent : MonoBehaviour
    {
        public Transform HandPosition => GripIKLocation;
        [SerializeField] private Transform GripIKLocation;

        public bool Firing { get; private set; }
        public bool Reloading { get; private set; }

        public WeaponStats WeaponStats;

        protected Camera MainCamera;
        protected WeaponHolder WeaponHolder;
        protected CrosshairScript CrosshairComponent;

        private void Awake()
        {
            MainCamera = Camera.main;
        }

        public void Initialize(WeaponHolder weaponHolder, CrosshairScript crosshair)
        {
            WeaponHolder = weaponHolder;
            CrosshairComponent = crosshair;
        }

        public virtual void StartFiring()
        {
            Firing = true;

            //Check repeating
            if(WeaponStats.Repeating)
            {
                InvokeRepeating(nameof(FireWeapon), WeaponStats.FireStartDelay, WeaponStats.FireRate);
            }
            else
            {
                FireWeapon();
            }
        }

        public virtual void StopFiring()
        {
            Firing = false;
            CancelInvoke(nameof(FireWeapon));
        }

        protected virtual void FireWeapon()
        {
            WeaponStats.BulletsInClip--;
        }

        public void StartReloading()
        {
            Reloading = true;
            ReloadWeapon();
        }

        public void StopReloading()
        {
            Reloading = false;
        }


        private void ReloadWeapon()
        {
            int bulletsToReload = WeaponStats.ClipSize - WeaponStats.BulletsAvailable;
            if (bulletsToReload < 0)
            {
                WeaponStats.BulletsInClip = WeaponStats.ClipSize;
                WeaponStats.BulletsAvailable -= WeaponStats.ClipSize;
            }
            else
            {
                WeaponStats.BulletsInClip = WeaponStats.BulletsAvailable;
                WeaponStats.BulletsAvailable = 0;
            }
        }
    }
}