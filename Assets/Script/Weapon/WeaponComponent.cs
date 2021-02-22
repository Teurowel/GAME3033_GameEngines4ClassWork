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
        public int TotalBulletsAvailable;
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
        [SerializeField] protected Transform ParticleSpawnLocation;

        public bool Firing { get; private set; }
        public bool Reloading { get; private set; }

        public WeaponStats WeaponStats;

        [SerializeField] protected GameObject FiringAnimation;

        protected Camera MainCamera;
        protected WeaponHolder WeaponHolder;
        protected CrosshairScript CrosshairComponent;
        protected ParticleSystem FiringEffect; //gun shot fx

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
                CancelInvoke(nameof(FireWeapon));
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

            //Destroy firing effect
            if (FiringEffect != null)
            {
                Destroy(FiringEffect.gameObject);
            }

            CancelInvoke(nameof(FireWeapon));
        }

        protected virtual void FireWeapon()
        {
            WeaponStats.BulletsInClip--;
        }

        public virtual void StartReloading()
        {
            Reloading = true;
            ReloadWeapon();
        }

        public virtual void StopReloading()
        {
            Reloading = false;
        }


        protected virtual void ReloadWeapon()
        {
            //Destroy firing effect
            if(FiringEffect != null)
            {
                Destroy(FiringEffect.gameObject);
            }

            int bulletsToReload = WeaponStats.ClipSize - WeaponStats.TotalBulletsAvailable;
            if (bulletsToReload < 0)
            {
                //We have more bulllet than clip size
                WeaponStats.BulletsInClip = WeaponStats.ClipSize;
                WeaponStats.TotalBulletsAvailable -= WeaponStats.ClipSize;
            }
            else
            {
                //We have not enough bullet than clip size
                WeaponStats.BulletsInClip = WeaponStats.TotalBulletsAvailable;
                WeaponStats.TotalBulletsAvailable = 0;
            }
        }
    }
}