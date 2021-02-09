using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Weapons;

public class WeaponInfoUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI CurrentClipText;
    [SerializeField] TextMeshProUGUI WeaponNameText;
    [SerializeField] TextMeshProUGUI TotalAmmoText;

    private WeaponComponent EquippedWeapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        //Subscribe event
        PlayerEvents.OnWeaponEquipped += OnWeaponEquipped;
    }

    private void OnDisable()
    {
        //Unsubscribe event
        PlayerEvents.OnWeaponEquipped -= OnWeaponEquipped;
    }

    private void OnWeaponEquipped(WeaponComponent weapon)
    {
        EquippedWeapon = weapon;
        WeaponNameText.text = weapon.WeaponStats.Name;
    }

    // Update is called once per frame
    void Update()
    {
        if (EquippedWeapon != null)
        {
            CurrentClipText.text = EquippedWeapon.WeaponStats.BulletsInClip.ToString();
            TotalAmmoText.text = EquippedWeapon.WeaponStats.TotalBulletsAvailable.ToString();
        }
    }
}
