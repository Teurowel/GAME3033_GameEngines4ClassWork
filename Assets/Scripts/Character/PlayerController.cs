using Character.UI;
using System.Collections.Generic;
using System.Linq;
using Systems.Health_System;
using UnityEngine;
using UnityEngine.InputSystem;
using Weapons;

namespace Character
{
    public class PlayerController : MonoBehaviour, IPausable, ISavable
    {
        public CrossHairScript CrossHair => CrossHairComponent;
        [SerializeField] private CrossHairScript CrossHairComponent;

        

        public HealthComponent Health => HealthComponent;
        private HealthComponent HealthComponent;

        public InventoryComponent Inventory => InventoryComponent;
        private InventoryComponent InventoryComponent;

        public WeaponHolder WeaponHolder => WeaponHolderComponent;
        private WeaponHolder WeaponHolderComponent;

        private GameUIController GameUIController;
        private PlayerInput PlayerInput;

        [SerializeField] ConsumableScriptable Consume;

        public bool IsFiring;
        public bool IsReloading;
        public bool IsJumping;
        public bool IsRunning;
        public bool InInventory;

        private void Awake()
        {
            //Find GameUIController
            if (GameUIController == null)
            {
                GameUIController = FindObjectOfType<GameUIController>();
            }

            //FInd player input
            if(PlayerInput == null)
            {
                PlayerInput = GetComponent<PlayerInput>();
            }

            if(WeaponHolderComponent == null)
            {
                WeaponHolderComponent = GetComponent<WeaponHolder>();
            }

            if (HealthComponent == null)
            {
                HealthComponent = GetComponent<HealthComponent>();
            }

            if (InventoryComponent == null)
            {
                InventoryComponent = GetComponent<InventoryComponent>();
            }
        }

        private void Start()
        {
            //Consume.UseItem(this);
        }

        public void OnPauseGame()
        {
            PauseManager.Instance.PauseGame();
        }

        public void OnUnPauseGame()
        {
            PauseManager.Instance.UnPauseGame();
        }

        public void OnInventory(InputValue button)
        {
            //If we alreday opend inventory, close inventory
            if(InInventory)
            {
                InInventory = false;
                OpenInventory(false);
            }
            //Open inventory
            else
            {
                InInventory = true;
                OpenInventory(true);
            }
        }

        private void OpenInventory(bool open)
        {
            //Pause game and open inventory
            if(open == true)
            {
                PauseManager.Instance.PauseGame();
                GameUIController.EnableInventoryMenu();
            }
            //Unpause game and open game menu;
            else
            {
                PauseManager.Instance.UnPauseGame();
                GameUIController.EnableGameMenu();
            }
        }


        public void PauseGame()
        {
            GameUIController.EnablePauseMenu();

            //Switch player input map
            if(PlayerInput)
            {
                PlayerInput.SwitchCurrentActionMap("PauseActionMap");
            }
        }

        public void UnPauseGame()
        {
            GameUIController.EnableGameMenu();

            //Switch player input map
            if (PlayerInput)
            {
                PlayerInput.SwitchCurrentActionMap("PlayerActionMap");
            }
        }

        //Save all data
        public void OnSave(InputValue button)
        {
            SaveSystem.Instance.SaveGame();
        }

        //Load all data
        public void OnLoad(InputValue button)
        {
            SaveSystem.Instance.LoadGame();
        }

        public SaveDataBase SaveData()
        {
            //Transform, Health, name, Item List, Weapon Stats

            //Make PlayerSaveData class and populate it with all data that has to be saved
            PlayerSaveData saveData = new PlayerSaveData
            {
                Name = gameObject.name,
                Position = transform.position,
                Rotation = transform.rotation,
                CurrentHealth = HealthComponent.Health        
            };

            //If we have weapon, save
            if (WeaponHolder.EquippedWeapon != null)
            {
                saveData.EquippedWeaponData = new WeaponSaveData(WeaponHolder.EquippedWeapon.WeaponInformation);
            }
            else
            {
                saveData.EquippedWeaponData = null;
            }

            //Iterate through all item list and make ItemSaveData and then convert that to list
            var itemSaveList = Inventory.GetItemList().Select(item => new ItemSaveData(item)).ToList();
            saveData.ItemList = itemSaveList;

            return saveData;
        }

        public void LoadData(SaveDataBase saveData)
        {
            //Convert saveData to PlayerSaveData to get data;
            PlayerSaveData playerData = (PlayerSaveData)saveData;
            if(playerData == null)
            {
                return;
            }

            //Set all data
            Transform playerTransform = transform;
            playerTransform.position = playerData.Position;
            playerTransform.rotation = playerData.Rotation;
            Health.SetCurrentHealth(playerData.CurrentHealth);

            //Iterate through all itemSaveData and make new item using its name with InventoryRefernece
            foreach(ItemSaveData itemSaveData in playerData.ItemList)
            {
                ItemScriptables item = InventoryReferencer.Instance.GetItemReference(itemSaveData.Name);
                Inventory.AddItem(item, itemSaveData.Amount);
            }

            //If we have equipped weapon, find it in inventory and equip it
            if (playerData.EquippedWeaponData != null)
            {
                WeaponScriptable weapon = (WeaponScriptable)Inventory.FindItem(playerData.EquippedWeaponData.Name);
                if (weapon != null)
                {
                    weapon.WeaponStats = playerData.EquippedWeaponData.WeaponStats;
                    WeaponHolder.EquipWeapon(weapon);
                }
            }
        }

    }


}
