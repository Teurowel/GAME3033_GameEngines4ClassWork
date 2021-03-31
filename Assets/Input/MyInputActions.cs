// GENERATED AUTOMATICALLY FROM 'Assets/Input/MyInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MyInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MyInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MyInputActions"",
    ""maps"": [
        {
            ""name"": ""PlayerActionMap"",
            ""id"": ""12ca5926-ab61-4a59-b3fe-d835ca615304"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""3127965b-024d-4561-aaae-e96171b758e4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""06ff7b18-70f4-4aa1-acda-a957692d77a7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""70a709df-fa34-4e43-8bf7-0b87441a18a3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""875a8e4a-60df-4994-9546-7d99482ca1d6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""f69383dd-6afb-4026-9227-3dcaa236a249"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""0c42c237-f48b-48a0-8bb6-d452e82c5de0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""PauseGame"",
                    ""type"": ""Button"",
                    ""id"": ""61a20c21-9bb1-45a7-9867-1691aadc3c02"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""0c4d76be-fa8c-424f-8f99-2de689f6579e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""83389219-df6e-414a-9c4c-a3f176af0f8c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""203173bb-b8fb-4381-b267-57e6de2e1d90"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff8cdae0-6d42-4262-80b2-a9e06bba60f0"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fe0a86ff-0003-4a3f-854c-75b874b9bbe3"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Direction"",
                    ""id"": ""baab355f-1451-4a08-8e1b-dbcd73d874de"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""33496e00-43c0-444e-bf5a-704d4dc3070f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3063b178-9400-46b0-9529-02830ae8503c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""54c5dcaa-27f7-4511-829c-4fb14a4d5147"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c55c8230-49bb-459d-b3dc-17d6dc5c0543"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""593909ca-27c4-4fb9-bd53-df52a544fb40"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b15b6aa-0a73-465f-a225-6713e7fe5f89"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb0e30c8-36c4-4178-880f-7cbbb845208f"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PauseActionMap"",
            ""id"": ""66acef55-100f-4ef2-9e1a-fcd2780ad2f9"",
            ""actions"": [
                {
                    ""name"": ""UnPauseGame"",
                    ""type"": ""Button"",
                    ""id"": ""bb7e9955-2a16-4f71-b4bc-d156fb13c451"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""0787f0aa-2020-48ce-8152-ef7bb3e598b7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8fa03378-43b7-4910-9ba1-3d6a123d5960"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UnPauseGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf295493-eb25-4642-89a7-6c5793774cc6"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerActionMap
        m_PlayerActionMap = asset.FindActionMap("PlayerActionMap", throwIfNotFound: true);
        m_PlayerActionMap_Movement = m_PlayerActionMap.FindAction("Movement", throwIfNotFound: true);
        m_PlayerActionMap_Jump = m_PlayerActionMap.FindAction("Jump", throwIfNotFound: true);
        m_PlayerActionMap_Run = m_PlayerActionMap.FindAction("Run", throwIfNotFound: true);
        m_PlayerActionMap_Look = m_PlayerActionMap.FindAction("Look", throwIfNotFound: true);
        m_PlayerActionMap_Fire = m_PlayerActionMap.FindAction("Fire", throwIfNotFound: true);
        m_PlayerActionMap_Reload = m_PlayerActionMap.FindAction("Reload", throwIfNotFound: true);
        m_PlayerActionMap_PauseGame = m_PlayerActionMap.FindAction("PauseGame", throwIfNotFound: true);
        m_PlayerActionMap_Inventory = m_PlayerActionMap.FindAction("Inventory", throwIfNotFound: true);
        // PauseActionMap
        m_PauseActionMap = asset.FindActionMap("PauseActionMap", throwIfNotFound: true);
        m_PauseActionMap_UnPauseGame = m_PauseActionMap.FindAction("UnPauseGame", throwIfNotFound: true);
        m_PauseActionMap_Inventory = m_PauseActionMap.FindAction("Inventory", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // PlayerActionMap
    private readonly InputActionMap m_PlayerActionMap;
    private IPlayerActionMapActions m_PlayerActionMapActionsCallbackInterface;
    private readonly InputAction m_PlayerActionMap_Movement;
    private readonly InputAction m_PlayerActionMap_Jump;
    private readonly InputAction m_PlayerActionMap_Run;
    private readonly InputAction m_PlayerActionMap_Look;
    private readonly InputAction m_PlayerActionMap_Fire;
    private readonly InputAction m_PlayerActionMap_Reload;
    private readonly InputAction m_PlayerActionMap_PauseGame;
    private readonly InputAction m_PlayerActionMap_Inventory;
    public struct PlayerActionMapActions
    {
        private @MyInputActions m_Wrapper;
        public PlayerActionMapActions(@MyInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerActionMap_Movement;
        public InputAction @Jump => m_Wrapper.m_PlayerActionMap_Jump;
        public InputAction @Run => m_Wrapper.m_PlayerActionMap_Run;
        public InputAction @Look => m_Wrapper.m_PlayerActionMap_Look;
        public InputAction @Fire => m_Wrapper.m_PlayerActionMap_Fire;
        public InputAction @Reload => m_Wrapper.m_PlayerActionMap_Reload;
        public InputAction @PauseGame => m_Wrapper.m_PlayerActionMap_PauseGame;
        public InputAction @Inventory => m_Wrapper.m_PlayerActionMap_Inventory;
        public InputActionMap Get() { return m_Wrapper.m_PlayerActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActionMapActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActionMapActions instance)
        {
            if (m_Wrapper.m_PlayerActionMapActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnJump;
                @Run.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnRun;
                @Look.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnLook;
                @Fire.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnFire;
                @Reload.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnReload;
                @PauseGame.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnPauseGame;
                @PauseGame.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnPauseGame;
                @PauseGame.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnPauseGame;
                @Inventory.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnInventory;
            }
            m_Wrapper.m_PlayerActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @PauseGame.started += instance.OnPauseGame;
                @PauseGame.performed += instance.OnPauseGame;
                @PauseGame.canceled += instance.OnPauseGame;
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
            }
        }
    }
    public PlayerActionMapActions @PlayerActionMap => new PlayerActionMapActions(this);

    // PauseActionMap
    private readonly InputActionMap m_PauseActionMap;
    private IPauseActionMapActions m_PauseActionMapActionsCallbackInterface;
    private readonly InputAction m_PauseActionMap_UnPauseGame;
    private readonly InputAction m_PauseActionMap_Inventory;
    public struct PauseActionMapActions
    {
        private @MyInputActions m_Wrapper;
        public PauseActionMapActions(@MyInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @UnPauseGame => m_Wrapper.m_PauseActionMap_UnPauseGame;
        public InputAction @Inventory => m_Wrapper.m_PauseActionMap_Inventory;
        public InputActionMap Get() { return m_Wrapper.m_PauseActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PauseActionMapActions set) { return set.Get(); }
        public void SetCallbacks(IPauseActionMapActions instance)
        {
            if (m_Wrapper.m_PauseActionMapActionsCallbackInterface != null)
            {
                @UnPauseGame.started -= m_Wrapper.m_PauseActionMapActionsCallbackInterface.OnUnPauseGame;
                @UnPauseGame.performed -= m_Wrapper.m_PauseActionMapActionsCallbackInterface.OnUnPauseGame;
                @UnPauseGame.canceled -= m_Wrapper.m_PauseActionMapActionsCallbackInterface.OnUnPauseGame;
                @Inventory.started -= m_Wrapper.m_PauseActionMapActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_PauseActionMapActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_PauseActionMapActionsCallbackInterface.OnInventory;
            }
            m_Wrapper.m_PauseActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @UnPauseGame.started += instance.OnUnPauseGame;
                @UnPauseGame.performed += instance.OnUnPauseGame;
                @UnPauseGame.canceled += instance.OnUnPauseGame;
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
            }
        }
    }
    public PauseActionMapActions @PauseActionMap => new PauseActionMapActions(this);
    public interface IPlayerActionMapActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnPauseGame(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
    }
    public interface IPauseActionMapActions
    {
        void OnUnPauseGame(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
    }
}
