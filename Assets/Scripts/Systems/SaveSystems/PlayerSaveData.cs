using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class that holds all data that has to be saved
namespace Character
{
    [System.Serializable]
    public class PlayerSaveData : SaveDataBase
    {
        public float CurrentHealth;
        public Vector3 Position;
        public Quaternion Rotation;
        public WeaponSaveData EquippedWeaponData;
        public List<ItemSaveData> ItemList;
    }
}
