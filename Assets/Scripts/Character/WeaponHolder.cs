using System;
using Character.UI;
using Parent;
using UnityEngine;
using UnityEngine.InputSystem;
using Weapons;

namespace Character
{
    public class WeaponHolder : MonoBehaviour// InputMonoBehaviour
    {
        [Header("Weapon To Spawn"), SerializeField]
        private WeaponScriptable WeaponToSpawn;

        [SerializeField] private Transform WeaponSocketLocation;

        private Transform GripIKLocation;
        private bool WasFiring = false;
        private bool FiringPressed = false;
        
        //Components
        public PlayerController Controller => PlayerController;
        private PlayerController PlayerController;
        
        private CrossHairScript PlayerCrosshair;
        private Animator PlayerAnimator;
        
        //Ref
        private Camera ViewCamera;

        public WeaponComponent EquippedWeapon => WeaponComponent;
        private WeaponComponent WeaponComponent;
        
        

        private static readonly int AimHorizontalHash = Animator.StringToHash("AimHorizontal");
        private static readonly int AimVerticalHash = Animator.StringToHash("AimVertical");
        private static readonly int IsFiringHash = Animator.StringToHash("IsFiring");
        private static readonly int IsReloadingHash = Animator.StringToHash("IsReloading");
        private static readonly int WeaponTypeHash = Animator.StringToHash("WeaponType");


        private void Awake()
        {            
            PlayerAnimator = GetComponent<Animator>();
            PlayerController = GetComponent<PlayerController>();
            if (PlayerController)
            {
                PlayerCrosshair = PlayerController.CrossHair;
            }
            
            ViewCamera = Camera.main;
        }

        // Start is called before the first frame update
        void Start()
        {
            if (WeaponToSpawn)
            {
                EquipWeapon(WeaponToSpawn);
            }
        }

        private void OnAnimatorIK(int layerIndex)
        {
            if(GripIKLocation == null)
            {
                return;
            }

            PlayerAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
            PlayerAnimator.SetIKPosition(AvatarIKGoal.LeftHand, GripIKLocation.position);
        }
        
        private void OnFire(InputValue obj)
        {
            FiringPressed = obj.isPressed;

            if(WeaponComponent == null)
            {
                return;
            }


            if (FiringPressed)
                StartFiring();
            else
                StopFiring();
            
        }

        private void StartFiring()
        {
            //TODO: Weapon Seems to be reloading after no bullets left
            if (WeaponComponent.WeaponInformation.BulletsAvailable <= 0 &&
                WeaponComponent.WeaponInformation.BulletsInClip <= 0) return;
       
            PlayerController.IsFiring = true;
            PlayerAnimator.SetBool(IsFiringHash, true);
            WeaponComponent.StartFiringWeapon();
        }

        private void StopFiring()
        {
            PlayerController.IsFiring = false;
            PlayerAnimator.SetBool(IsFiringHash, false);
            WeaponComponent.StopFiringWeapon();
        }

        
        private void OnReload(InputValue button)
        {
            if (WeaponComponent == null)
            {
                return;
            }

            StartReloading();
        }

        public void StartReloading()
        {
            if (WeaponComponent.WeaponInformation.BulletsAvailable <= 0 && PlayerController.IsFiring)
            {
                StopFiring();
                return;
            }

            PlayerController.IsReloading = true;
            PlayerAnimator.SetBool(IsReloadingHash, true);
            WeaponComponent.StartReloading();
            
            InvokeRepeating(nameof(StopReloading), 0, .1f);
        }
        
        private void StopReloading()
        {
            if (PlayerAnimator.GetBool(IsReloadingHash)) return;
            
            PlayerController.IsReloading = false;
            WeaponComponent.StopReloading();
            CancelInvoke(nameof(StopReloading));
            
            if (!WasFiring || !FiringPressed) return;
            
            StartFiring();
            WasFiring = false;
        }
        
        private void OnLook(InputValue obj)
        {
            Vector3 independentMousePosition = ViewCamera.ScreenToViewportPoint(PlayerCrosshair.CurrentAimPosition);
            
            PlayerAnimator.SetFloat(AimHorizontalHash, independentMousePosition.x);
            PlayerAnimator.SetFloat(AimVerticalHash, independentMousePosition.y);
        }
        
        //private new void OnEnable()
        //{
        //    base.OnEnable();
        //    GameInput.PlayerActionMap.Look.performed += OnLook;
        //    GameInput.PlayerActionMap.Fire.performed += OnFire;
            
        //}
        
        //private new void OnDisable()
        //{
        //    base.OnDisable();
        //    GameInput.PlayerActionMap.Look.performed -= OnLook;
        //    GameInput.PlayerActionMap.Fire.performed -= OnFire;
        //}

        public void EquipWeapon(WeaponScriptable weaponScriptable)
        {
            //Spawn waepon from weapon prefab
            GameObject spawnedWeapon = Instantiate(weaponScriptable.ItemPrefab, WeaponSocketLocation.position, WeaponSocketLocation.rotation, WeaponSocketLocation);
            if (!spawnedWeapon) return;

            //Get weapon component
            WeaponComponent = spawnedWeapon.GetComponent<WeaponComponent>();
            if (!WeaponComponent) return;

            //Initialize weapon with weapon scriptable
            WeaponComponent.Initialize(this, weaponScriptable);

            PlayerEvents.Invoke_OnWeaponEquipped(WeaponComponent);

            GripIKLocation = WeaponComponent.GripLocation;
            PlayerAnimator.SetInteger(WeaponTypeHash, (int)WeaponComponent.WeaponInformation.WeaponType);
        }

        public void UnEquipWeapon()
        {
            Destroy(WeaponComponent.gameObject);
            WeaponComponent = null;
        }
    }
}
