using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

public class PlayerEvents
{
    public delegate void WeaponEquipped(WeaponComponent weapon);

    public static event WeaponEquipped OnWeaponEquipped; //WeaponInfoUI subscirbe this

    public static void Invoke_OnWeaponEquipped(WeaponComponent weapon)
    {
        OnWeaponEquipped?.Invoke(weapon);
    }
}
