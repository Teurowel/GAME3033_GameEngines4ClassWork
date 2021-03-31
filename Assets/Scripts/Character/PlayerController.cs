using Character.UI;
using Systems.Health_System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Character
{
    public class PlayerController : MonoBehaviour, IPausable
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
            Health.TakeDamage(50);
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
    }
}
