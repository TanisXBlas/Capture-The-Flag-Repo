// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""2a96c8ed-2ffe-4e6b-9f45-cffadb508c81"",
            ""actions"": [
                {
                    ""name"": ""Buttons"",
                    ""type"": ""Button"",
                    ""id"": ""f645502a-25d2-4b81-ad7f-e3198a94c28c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""133e51a2-6fec-4bfc-9080-0f5cb4ee8155"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Horizontal Look"",
                    ""type"": ""Value"",
                    ""id"": ""66f675c1-3979-47a4-ac15-cd1e97c9bc8d"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Vertical Look"",
                    ""type"": ""Value"",
                    ""id"": ""0b11f9a3-68d5-4728-bad3-bfa640024582"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0a4740d9-5fbc-4e5f-b0df-167dac27b14f"",
                    ""path"": ""<HID::Bensussen Deutsch & Associates,Inc.(BDA) NSW Spectra Wired Controller>/button2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Buttons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""86f801a4-fda3-4199-a755-47a0e2b9cd66"",
                    ""path"": ""<HID::Bensussen Deutsch & Associates,Inc.(BDA) NSW Spectra Wired Controller>/button3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Buttons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a59f154f-0272-4a45-b9f0-d7799fe14e9d"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XBox Controller"",
                    ""action"": ""Buttons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""825afcda-35f5-4d52-9d37-8d297f9fece7"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XBox Controller"",
                    ""action"": ""Buttons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""af5a6a01-32b1-46cb-bff1-1b63de67fff3"",
                    ""path"": ""<Joystick>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""591d7667-02dc-42fd-9754-67e8347fd2e1"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XBox Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c80e1ae-677e-4162-bbde-685693f32557"",
                    ""path"": ""<Gamepad>/leftStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XBox Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee15fb20-922d-4491-9b7f-4bd9a1e3dfe3"",
                    ""path"": ""<HID::Bensussen Deutsch & Associates,Inc.(BDA) NSW Spectra Wired Controller>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Horizontal Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73be6af0-04be-47da-87fc-4e0f969a055d"",
                    ""path"": ""<Gamepad>/rightStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XBox Controller"",
                    ""action"": ""Horizontal Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8edc920b-352b-4f11-abcb-db696f316420"",
                    ""path"": ""<HID::Bensussen Deutsch & Associates,Inc.(BDA) NSW Spectra Wired Controller>/rz"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Vertical Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6450e500-8ea6-4912-bfff-63c56bdc19db"",
                    ""path"": ""<Gamepad>/rightStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XBox Controller"",
                    ""action"": ""Vertical Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player 2"",
            ""id"": ""ee0c7231-30ee-4191-8f10-e4715831ea37"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""16527d3b-1f77-40fb-8f40-2b4830aba2c1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Keys"",
                    ""type"": ""Button"",
                    ""id"": ""4516cafe-bd69-4301-8777-700b07695134"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""9ac6817b-03a1-4a6f-b8b4-97c219a1cd30"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b5696753-b10d-43ec-ba16-10b1dd3dfb1d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7affde3f-560a-4933-83c5-b2847ba7d7bf"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""644d1808-9103-4800-96a9-8036a081dc67"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""cb63b331-44c2-47ac-83cf-ce5711d79b6b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""461a3bc6-ac0e-4f8c-99be-846ab5d0d32e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Keys"",
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
                }
            ]
        },
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<HID::Bensussen Deutsch & Associates,Inc.(BDA) NSW Spectra Wired Controller>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""XBox Controller"",
            ""bindingGroup"": ""XBox Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Buttons = m_Player.FindAction("Buttons", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_HorizontalLook = m_Player.FindAction("Horizontal Look", throwIfNotFound: true);
        m_Player_VerticalLook = m_Player.FindAction("Vertical Look", throwIfNotFound: true);
        // Player 2
        m_Player2 = asset.FindActionMap("Player 2", throwIfNotFound: true);
        m_Player2_Move = m_Player2.FindAction("Move", throwIfNotFound: true);
        m_Player2_Keys = m_Player2.FindAction("Keys", throwIfNotFound: true);
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
    private readonly InputAction m_Player_Buttons;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_HorizontalLook;
    private readonly InputAction m_Player_VerticalLook;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Buttons => m_Wrapper.m_Player_Buttons;
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @HorizontalLook => m_Wrapper.m_Player_HorizontalLook;
        public InputAction @VerticalLook => m_Wrapper.m_Player_VerticalLook;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Buttons.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtons;
                @Buttons.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtons;
                @Buttons.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtons;
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @HorizontalLook.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHorizontalLook;
                @HorizontalLook.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHorizontalLook;
                @HorizontalLook.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHorizontalLook;
                @VerticalLook.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnVerticalLook;
                @VerticalLook.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnVerticalLook;
                @VerticalLook.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnVerticalLook;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Buttons.started += instance.OnButtons;
                @Buttons.performed += instance.OnButtons;
                @Buttons.canceled += instance.OnButtons;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @HorizontalLook.started += instance.OnHorizontalLook;
                @HorizontalLook.performed += instance.OnHorizontalLook;
                @HorizontalLook.canceled += instance.OnHorizontalLook;
                @VerticalLook.started += instance.OnVerticalLook;
                @VerticalLook.performed += instance.OnVerticalLook;
                @VerticalLook.canceled += instance.OnVerticalLook;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Player 2
    private readonly InputActionMap m_Player2;
    private IPlayer2Actions m_Player2ActionsCallbackInterface;
    private readonly InputAction m_Player2_Move;
    private readonly InputAction m_Player2_Keys;
    public struct Player2Actions
    {
        private @PlayerControls m_Wrapper;
        public Player2Actions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player2_Move;
        public InputAction @Keys => m_Wrapper.m_Player2_Keys;
        public InputActionMap Get() { return m_Wrapper.m_Player2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player2Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer2Actions instance)
        {
            if (m_Wrapper.m_Player2ActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMove;
                @Keys.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnKeys;
                @Keys.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnKeys;
                @Keys.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnKeys;
            }
            m_Wrapper.m_Player2ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Keys.started += instance.OnKeys;
                @Keys.performed += instance.OnKeys;
                @Keys.canceled += instance.OnKeys;
            }
        }
    }
    public Player2Actions @Player2 => new Player2Actions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    private int m_XBoxControllerSchemeIndex = -1;
    public InputControlScheme XBoxControllerScheme
    {
        get
        {
            if (m_XBoxControllerSchemeIndex == -1) m_XBoxControllerSchemeIndex = asset.FindControlSchemeIndex("XBox Controller");
            return asset.controlSchemes[m_XBoxControllerSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnButtons(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnHorizontalLook(InputAction.CallbackContext context);
        void OnVerticalLook(InputAction.CallbackContext context);
    }
    public interface IPlayer2Actions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnKeys(InputAction.CallbackContext context);
    }
}
