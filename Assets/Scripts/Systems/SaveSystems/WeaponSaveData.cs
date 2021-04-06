using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

namespace Character
{
    [System.Serializable]
    public class WeaponSaveData : SaveDataBase
    {
        public WeaponStats WeaponStats;

        public WeaponSaveData(WeaponStats weaponStats)
        {
            Name = weaponStats.WeaponName;
            WeaponStats = weaponStats;
        }
    }
}
