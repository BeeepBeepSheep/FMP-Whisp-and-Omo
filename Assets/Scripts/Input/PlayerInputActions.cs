// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""8e83d194-8563-4f46-98ca-5043b2ba5113"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""793eaae7-d058-4af8-bec2-abd10c080bfd"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""StickDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""fbb410e0-616e-4704-8e23-0c1776c610dd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""PauseUnpause"",
                    ""type"": ""Button"",
                    ""id"": ""d8099e68-f8c6-4c2f-9e6b-9dd448fb788d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b4bf5ccb-0ebb-4d68-93d1-05d4ae32b1d5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""WhispAbility1"",
                    ""type"": ""Button"",
                    ""id"": ""487d4251-b370-4f66-9344-3d58d2564009"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""ToggleCameraShoulder"",
                    ""type"": ""Button"",
                    ""id"": ""1bdb7d1e-150b-4c5a-b685-629ebf84a168"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""ReturnWhisp"",
                    ""type"": ""Button"",
                    ""id"": ""9cf5eeb1-5a8e-40c7-8d3f-1fb93d471d33"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""SkipCutscene"",
                    ""type"": ""Button"",
                    ""id"": ""8ca3cc86-4ba1-4fd0-8dda-97384ad61db1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""UIBack"",
                    ""type"": ""Button"",
                    ""id"": ""0b28a3c6-dd32-4d88-9c67-880315152478"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1d5b9a25-b7ff-4bad-b3c6-c3d5ce5ae992"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a5989c2-8bd8-477b-a8b7-5f74f9fdc950"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""f066ce75-6b77-430b-b6a9-aa928c70c2b8"",
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
                    ""id"": ""26b31f56-50e1-4a01-885d-4c19212499ca"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8297ec7d-9ddf-4e9b-a52b-802f20257734"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7471c194-07c0-40cb-8c0e-95fb7a49606a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9b9ebbfe-e3e8-429b-aa66-1e44cdbd1022"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""7126cec9-915d-4687-bac9-d1faac65f760"",
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
                    ""id"": ""448adb2f-0179-4994-9f3c-8ee6c322f963"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3c0a4893-8608-412c-bfd9-7eae409b2978"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""65551abb-d1b9-4545-9827-d3d183a09353"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""edb0c52d-9ae3-45a1-8c5c-146a4c9a1b87"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a0fa6e83-6d1c-4775-9c0a-1d06c1f434ed"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone(min=0.05,max=0.9)"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""544da07a-d243-4544-a2dc-d8be19df7a26"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""PauseUnpause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ba9d2c0c-c9ac-4098-b372-bef7cab0e01f"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""PauseUnpause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""973d1d37-d7b1-495d-841d-8ebba6453c8c"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""PauseUnpause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""61b736ee-c4f2-4fd8-9743-141bfc7c0394"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""InvertVector2(invertX=false,invertY=false),StickDeadzone"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""92a8983a-c1f5-4751-aea7-cb5977a7f87d"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": ""InvertVector2(invertX=false,invertY=false)"",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac72e260-ab86-4950-81b5-6d6753768a8f"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""WhispAbility1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b94ea9df-f1cb-4fb9-96ea-28620e099035"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""WhispAbility1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d9a18d66-49a6-4758-b991-fb9ed177d32d"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""ToggleCameraShoulder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8142db7d-1fed-4599-b1aa-38499e6cab7e"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ToggleCameraShoulder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""56762864-8e21-4b34-81a3-a02dac20b24e"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReturnWhisp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""002c1e01-278e-4635-9943-2d225bc55cba"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReturnWhisp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""25008f88-6bee-417c-84e0-0d3e0aa6eef5"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""SkipCutscene"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72e70dfa-22fb-4cf2-8311-86fbac2dd3bd"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SkipCutscene"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eea3281b-c2fd-41d4-b861-94cf38fbe89e"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UIBack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse and Keyboard"",
            ""bindingGroup"": ""Mouse and Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_PauseUnpause = m_Player.FindAction("PauseUnpause", throwIfNotFound: true);
        m_Player_Look = m_Player.FindAction("Look", throwIfNotFound: true);
        m_Player_WhispAbility1 = m_Player.FindAction("WhispAbility1", throwIfNotFound: true);
        m_Player_ToggleCameraShoulder = m_Player.FindAction("ToggleCameraShoulder", throwIfNotFound: true);
        m_Player_ReturnWhisp = m_Player.FindAction("ReturnWhisp", throwIfNotFound: true);
        m_Player_SkipCutscene = m_Player.FindAction("SkipCutscene", throwIfNotFound: true);
        m_Player_UIBack = m_Player.FindAction("UIBack", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_PauseUnpause;
    private readonly InputAction m_Player_Look;
    private readonly InputAction m_Player_WhispAbility1;
    private readonly InputAction m_Player_ToggleCameraShoulder;
    private readonly InputAction m_Player_ReturnWhisp;
    private readonly InputAction m_Player_SkipCutscene;
    private readonly InputAction m_Player_UIBack;
    public struct PlayerActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @PauseUnpause => m_Wrapper.m_Player_PauseUnpause;
        public InputAction @Look => m_Wrapper.m_Player_Look;
        public InputAction @WhispAbility1 => m_Wrapper.m_Player_WhispAbility1;
        public InputAction @ToggleCameraShoulder => m_Wrapper.m_Player_ToggleCameraShoulder;
        public InputAction @ReturnWhisp => m_Wrapper.m_Player_ReturnWhisp;
        public InputAction @SkipCutscene => m_Wrapper.m_Player_SkipCutscene;
        public InputAction @UIBack => m_Wrapper.m_Player_UIBack;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @PauseUnpause.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPauseUnpause;
                @PauseUnpause.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPauseUnpause;
                @PauseUnpause.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPauseUnpause;
                @Look.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @WhispAbility1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWhispAbility1;
                @WhispAbility1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWhispAbility1;
                @WhispAbility1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWhispAbility1;
                @ToggleCameraShoulder.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleCameraShoulder;
                @ToggleCameraShoulder.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleCameraShoulder;
                @ToggleCameraShoulder.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleCameraShoulder;
                @ReturnWhisp.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReturnWhisp;
                @ReturnWhisp.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReturnWhisp;
                @ReturnWhisp.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReturnWhisp;
                @SkipCutscene.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkipCutscene;
                @SkipCutscene.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkipCutscene;
                @SkipCutscene.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkipCutscene;
                @UIBack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUIBack;
                @UIBack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUIBack;
                @UIBack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUIBack;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @PauseUnpause.started += instance.OnPauseUnpause;
                @PauseUnpause.performed += instance.OnPauseUnpause;
                @PauseUnpause.canceled += instance.OnPauseUnpause;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @WhispAbility1.started += instance.OnWhispAbility1;
                @WhispAbility1.performed += instance.OnWhispAbility1;
                @WhispAbility1.canceled += instance.OnWhispAbility1;
                @ToggleCameraShoulder.started += instance.OnToggleCameraShoulder;
                @ToggleCameraShoulder.performed += instance.OnToggleCameraShoulder;
                @ToggleCameraShoulder.canceled += instance.OnToggleCameraShoulder;
                @ReturnWhisp.started += instance.OnReturnWhisp;
                @ReturnWhisp.performed += instance.OnReturnWhisp;
                @ReturnWhisp.canceled += instance.OnReturnWhisp;
                @SkipCutscene.started += instance.OnSkipCutscene;
                @SkipCutscene.performed += instance.OnSkipCutscene;
                @SkipCutscene.canceled += instance.OnSkipCutscene;
                @UIBack.started += instance.OnUIBack;
                @UIBack.performed += instance.OnUIBack;
                @UIBack.canceled += instance.OnUIBack;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_MouseandKeyboardSchemeIndex = -1;
    public InputControlScheme MouseandKeyboardScheme
    {
        get
        {
            if (m_MouseandKeyboardSchemeIndex == -1) m_MouseandKeyboardSchemeIndex = asset.FindControlSchemeIndex("Mouse and Keyboard");
            return asset.controlSchemes[m_MouseandKeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnPauseUnpause(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnWhispAbility1(InputAction.CallbackContext context);
        void OnToggleCameraShoulder(InputAction.CallbackContext context);
        void OnReturnWhisp(InputAction.CallbackContext context);
        void OnSkipCutscene(InputAction.CallbackContext context);
        void OnUIBack(InputAction.CallbackContext context);
    }
}
