// GENERATED AUTOMATICALLY FROM 'Assets/Input/GameInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInputActions"",
    ""maps"": [
        {
            ""name"": ""ThirdPerson"",
            ""id"": ""b97ff409-dad5-479c-a5a7-88ff6d26059e"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""5553fcd0-34c2-4cd8-b5d8-51aa8c28b3e4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""f1cc0731-8d3f-4be5-9b5a-5ee2088361ec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""9dd3e0dc-d45a-4e97-9c10-e601be900174"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""322bcb8d-e574-4e39-a849-6d989ff1ac47"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""37e56979-bff6-4193-9923-44f1dc421b06"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""67667f49-1b4e-4f95-b307-98748de9243d"",
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
                    ""id"": ""02728f5a-9c06-4014-b755-ee3a3f81ef60"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c70cc453-d0ba-454c-8451-fba9c7411c31"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""000e592f-07a9-4230-85ec-c75f3ef47ea4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""65120522-744e-46a1-bfa8-7af07e333db7"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""065abb36-4835-4a15-a98e-4380d5dd9573"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5fa5d514-b0fb-4f64-9931-893de4dd8c74"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<VirtualMouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // ThirdPerson
        m_ThirdPerson = asset.FindActionMap("ThirdPerson", throwIfNotFound: true);
        m_ThirdPerson_Movement = m_ThirdPerson.FindAction("Movement", throwIfNotFound: true);
        m_ThirdPerson_Jump = m_ThirdPerson.FindAction("Jump", throwIfNotFound: true);
        m_ThirdPerson_Fire = m_ThirdPerson.FindAction("Fire", throwIfNotFound: true);
        m_ThirdPerson_Run = m_ThirdPerson.FindAction("Run", throwIfNotFound: true);
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

    // ThirdPerson
    private readonly InputActionMap m_ThirdPerson;
    private IThirdPersonActions m_ThirdPersonActionsCallbackInterface;
    private readonly InputAction m_ThirdPerson_Movement;
    private readonly InputAction m_ThirdPerson_Jump;
    private readonly InputAction m_ThirdPerson_Fire;
    private readonly InputAction m_ThirdPerson_Run;
    public struct ThirdPersonActions
    {
        private @GameInputActions m_Wrapper;
        public ThirdPersonActions(@GameInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_ThirdPerson_Movement;
        public InputAction @Jump => m_Wrapper.m_ThirdPerson_Jump;
        public InputAction @Fire => m_Wrapper.m_ThirdPerson_Fire;
        public InputAction @Run => m_Wrapper.m_ThirdPerson_Run;
        public InputActionMap Get() { return m_Wrapper.m_ThirdPerson; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ThirdPersonActions set) { return set.Get(); }
        public void SetCallbacks(IThirdPersonActions instance)
        {
            if (m_Wrapper.m_ThirdPersonActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnJump;
                @Fire.started -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnFire;
                @Run.started -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnRun;
            }
            m_Wrapper.m_ThirdPersonActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
            }
        }
    }
    public ThirdPersonActions @ThirdPerson => new ThirdPersonActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IThirdPersonActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
    }
}
