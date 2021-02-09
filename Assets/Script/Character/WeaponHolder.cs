using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Weapons;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private GameObject Weapon;
    [SerializeField] private Transform WeaponSocket;


    private Transform GripLocation;



    //Components
    public PlayerController Controller => PlayerController;
    private PlayerController PlayerController;

    private CrosshairScript PlayerCrosshair;
    private Animator PlayerAnimator;

    bool WasFiring = false; //Was player firing weapon before reloading?
    bool FiringPressed = false;
    



    //Ref
    private Camera MainCamera;
    private WeaponComponent EquippedWeapon;



    //Animator Hashes
    private readonly int AimVerticalHash = Animator.StringToHash("AimVertical");
    private readonly int AimHorizontalHash = Animator.StringToHash("AimHorizontal");
    private readonly int IsFiringHash = Animator.StringToHash("IsFiring");
    private readonly int IsReloadingHash = Animator.StringToHash("IsReloading");
    private readonly int WeaponTypeHash = Animator.StringToHash("WeaponType");

    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
        PlayerAnimator = GetComponent<Animator>();

        if (PlayerController)
        {
            PlayerCrosshair = PlayerController.CrosshairComponent;
        }

        MainCamera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject spawnedWeapon = Instantiate(Weapon, WeaponSocket.position, WeaponSocket.rotation);

        if (!spawnedWeapon) return;

        spawnedWeapon.transform.parent = WeaponSocket;
        EquippedWeapon = spawnedWeapon.GetComponent<WeaponComponent>();

        GripLocation = EquippedWeapon.HandPosition;

        EquippedWeapon.Initialize(this, PlayerController.CrosshairComponent);
        PlayerAnimator.SetInteger(WeaponTypeHash, (int)EquippedWeapon.WeaponStats.WeaponType); //Set weapon type to animator to player proper anim

        PlayerEvents.Invoke_OnWeaponEquipped(EquippedWeapon);
    }

    public void OnLook(InputValue delta)
    {
        Vector3 independantMousePosition = MainCamera.ScreenToViewportPoint(PlayerController.CrosshairComponent.CurrentMousePosition);

        //Debug.Log(independantMousePosition);
        PlayerAnimator.SetFloat(AimVerticalHash, independantMousePosition.y);
        PlayerAnimator.SetFloat(AimHorizontalHash, independantMousePosition.x);
    }

    public void OnFire(InputValue button)
    {
        //Debug.Log("OnFire");

        FiringPressed = button.isPressed;
        //If left mouse is preesed
        if(FiringPressed)
        {
            StartFiring();
        }
        else
        {
            StopFiring();
        }
    }

    private void StartFiring()
    {
        //If we don't have any bullets left
        if(EquippedWeapon.WeaponStats.TotalBulletsAvailable <= 0 &&
            EquippedWeapon.WeaponStats.BulletsInClip <= 0)
        {
            return;
        }

        PlayerController.IsFiring = true;
        PlayerAnimator.SetBool(IsFiringHash, PlayerController.IsFiring);
        EquippedWeapon.StartFiring();
    }

    private void StopFiring()
    {
        PlayerController.IsFiring = false;
        PlayerAnimator.SetBool(IsFiringHash, PlayerController.IsFiring);
        EquippedWeapon.StopFiring();
    }

    public void OnReload(InputValue button)
    {
        // Debug.Log("OnReload");

        StartReloading();
    }

    public void StartReloading()
    {
        if(EquippedWeapon.WeaponStats.TotalBulletsAvailable <= 0 &&
            PlayerController.IsFiring)
        {
            StopFiring();
            return;
        }

        //If left mouse is preesed
        PlayerController.IsReloading = true;
        PlayerAnimator.SetBool(IsReloadingHash, PlayerController.IsReloading);
        EquippedWeapon.StartReloading();

        //Keep checking if reloading animation finished
        InvokeRepeating(nameof(StopReloading), 0, 0.1f);
    }

    public void StopReloading()
    {
        if(PlayerAnimator.GetBool(IsReloadingHash))
        {
            return;
        }

        PlayerController.IsReloading = false;
        EquippedWeapon.StopReloading();

        CancelInvoke(nameof(StopReloading));

        //Was player firing the weapon or firing button pressed. start firing again
        if (!WasFiring && !FiringPressed) return;
        StartFiring();
        WasFiring = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnAnimatorIK(int layerIndex)
    {
        PlayerAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
        PlayerAnimator.SetIKPosition(AvatarIKGoal.LeftHand, GripLocation.position);
    }
}
