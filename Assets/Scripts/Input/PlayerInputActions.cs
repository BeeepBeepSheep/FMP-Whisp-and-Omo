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
                    ""name"": ""Pause"",
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
                    ""name"": ""(testing only) ToggleMood"",
                    ""type"": ""Button"",
                    ""id"": ""a3b617e0-bb15-459d-b0e5-25bbad961f42"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""FocusToggle"",
                    ""type"": ""Button"",
                    ""id"": ""dc0f1a3d-34ee-42ec-b86e-f4857c143090"",
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
                    ""processors"": """",
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
                    ""action"": ""Pause"",
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
                    ""action"": ""Pause"",
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
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""67c328a2-a7e3-4545-a059-c0cd2acbbfdc"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""InvertVector2(invertX=false)"",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""61b736ee-c4f2-4fd8-9743-141bfc7c0394"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""InvertVector2(invertX=false)"",
                    ""groups"": ""Gamepad"",
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
                    ""id"": ""ff7dbea5-7e4c-4582-9a68-3c5f5d489140"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""(testing only) ToggleMood"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d62a56e-457d-43fa-9e47-22b86a23e8ff"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""(testing only) ToggleMood"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5599e378-cadb-46de-aae4-134147407180"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""FocusToggle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4673b31c-c801-4c42-ac90-856f6d79f493"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""FocusToggle"",
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
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""75722059-8324-4847-9185-10694d01432b"",
            ""actions"": [
                {
                    ""name"": ""UnPause"",
                    ""type"": ""Button"",
                    ""id"": ""6ae90a5f-fd72-44c7-b221-a77b87da36b5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7c97cb82-9459-4127-a70c-6f557acff47c"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UnPause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""86871a3d-5b0e-4491-ae7b-0bfa4f526124"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UnPause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6962d314-0191-4bf4-8c39-d208a53741c4"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UnPause"",
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
        m_Player_Pause = m_Player.FindAction("Pause", throwIfNotFound: true);
        m_Player_Look = m_Player.FindAction("Look", throwIfNotFound: true);
        m_Player_WhispAbility1 = m_Player.FindAction("WhispAbility1", throwIfNotFound: true);
        m_Player_ToggleCameraShoulder = m_Player.FindAction("ToggleCameraShoulder", throwIfNotFound: true);
        m_Player_testingonlyToggleMood = m_Player.FindAction("(testing only) ToggleMood", throwIfNotFound: true);
        m_Player_FocusToggle = m_Player.FindAction("FocusToggle", throwIfNotFound: true);
        m_Player_ReturnWhisp = m_Player.FindAction("ReturnWhisp", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_UnPause = m_UI.FindAction("UnPause", throwIfNotFound: true);
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
    private readonly InputAction m_Player_Pause;
    private readonly InputAction m_Player_Look;
    private readonly InputAction m_Player_WhispAbility1;
    private readonly InputAction m_Player_ToggleCameraShoulder;
    private readonly InputAction m_Player_testingonlyToggleMood;
    private readonly InputAction m_Player_FocusToggle;
    private readonly InputAction m_Player_ReturnWhisp;
    public struct PlayerActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Pause => m_Wrapper.m_Player_Pause;
        public InputAction @Look => m_Wrapper.m_Player_Look;
        public InputAction @WhispAbility1 => m_Wrapper.m_Player_WhispAbility1;
        public InputAction @ToggleCameraShoulder => m_Wrapper.m_Player_ToggleCameraShoulder;
        public InputAction @testingonlyToggleMood => m_Wrapper.m_Player_testingonlyToggleMood;
        public InputAction @FocusToggle => m_Wrapper.m_Player_FocusToggle;
        public InputAction @ReturnWhisp => m_Wrapper.m_Player_ReturnWhisp;
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
                @Pause.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Look.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @WhispAbility1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWhispAbility1;
                @WhispAbility1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWhispAbility1;
                @WhispAbility1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWhispAbility1;
                @ToggleCameraShoulder.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleCameraShoulder;
                @ToggleCameraShoulder.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleCameraShoulder;
                @ToggleCameraShoulder.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleCameraShoulder;
                @testingonlyToggleMood.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTestingonlyToggleMood;
                @testingonlyToggleMood.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTestingonlyToggleMood;
                @testingonlyToggleMood.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTestingonlyToggleMood;
                @FocusToggle.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFocusToggle;
                @FocusToggle.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFocusToggle;
                @FocusToggle.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFocusToggle;
                @ReturnWhisp.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReturnWhisp;
                @ReturnWhisp.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReturnWhisp;
                @ReturnWhisp.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReturnWhisp;
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
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @WhispAbility1.started += instance.OnWhispAbility1;
                @WhispAbility1.performed += instance.OnWhispAbility1;
                @WhispAbility1.canceled += instance.OnWhispAbility1;
                @ToggleCameraShoulder.started += instance.OnToggleCameraShoulder;
                @ToggleCameraShoulder.performed += instance.OnToggleCameraShoulder;
                @ToggleCameraShoulder.canceled += instance.OnToggleCameraShoulder;
                @testingonlyToggleMood.started += instance.OnTestingonlyToggleMood;
                @testingonlyToggleMood.performed += instance.OnTestingonlyToggleMood;
                @testingonlyToggleMood.canceled += instance.OnTestingonlyToggleMood;
                @FocusToggle.started += instance.OnFocusToggle;
                @FocusToggle.performed += instance.OnFocusToggle;
                @FocusToggle.canceled += instance.OnFocusToggle;
                @ReturnWhisp.started += instance.OnReturnWhisp;
                @ReturnWhisp.performed += instance.OnReturnWhisp;
                @ReturnWhisp.canceled += instance.OnReturnWhisp;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_UnPause;
    public struct UIActions
    {
        private @PlayerInputActions m_Wrapper;
        public UIActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @UnPause => m_Wrapper.m_UI_UnPause;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @UnPause.started -= m_Wrapper.m_UIActionsCallbackInterface.OnUnPause;
                @UnPause.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnUnPause;
                @UnPause.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnUnPause;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @UnPause.started += instance.OnUnPause;
                @UnPause.performed += instance.OnUnPause;
                @UnPause.canceled += instance.OnUnPause;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
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
        void OnPause(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnWhispAbility1(InputAction.CallbackContext context);
        void OnToggleCameraShoulder(InputAction.CallbackContext context);
        void OnTestingonlyToggleMood(InputAction.CallbackContext context);
        void OnFocusToggle(InputAction.CallbackContext context);
        void OnReturnWhisp(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnUnPause(InputAction.CallbackContext context);
    }
}
