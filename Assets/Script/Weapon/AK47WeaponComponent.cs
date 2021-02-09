﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public class AK47WeaponComponent : WeaponComponent
    {
        private Vector3 HitLocation;

        protected override void FireWeapon()
        {
            Debug.Log($"{WeaponStats.BulletsInClip} || {WeaponStats.TotalBulletsAvailable}");

            if (WeaponStats.BulletsInClip > 0 && !Reloading && !WeaponHolder.Controller.IsJumping)
            {
                base.FireWeapon();

                Ray screenRay = MainCamera.ScreenPointToRay(new Vector3(CrosshairComponent.CurrentMousePosition.x,
                    CrosshairComponent.CurrentMousePosition.y, 0));

                if (!Physics.Raycast(screenRay, out RaycastHit hit,
                    WeaponStats.FireDistance, WeaponStats.WeaponHitLayers)) return;

                HitLocation = hit.point;
                Debug.Log("Hit");

                Vector3 hitDirection = hit.point - MainCamera.transform.position;
                Debug.DrawRay(MainCamera.transform.position, hitDirection.normalized * WeaponStats.FireDistance, Color.red);
            }
            else if (WeaponStats.BulletsInClip <= 0)
            {
                if (!WeaponHolder) return;

                WeaponHolder.StartReloading();
            }


        }

        private void OnDrawGizmos()
        {
            if (HitLocation == Vector3.zero) return;

            Gizmos.DrawWireSphere(HitLocation, 0.2f);
        }
    }
}