// GENERATED AUTOMATICALLY FROM 'Assets/Settings/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Game"",
            ""id"": ""f3f4136d-2b4f-4f61-8942-cf3931cbdb0e"",
            ""actions"": [
                {
                    ""name"": ""Rock"",
                    ""type"": ""Button"",
                    ""id"": ""fc897b3d-a293-417f-936d-18dcd4754d61"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Paper"",
                    ""type"": ""Button"",
                    ""id"": ""ed97df81-cfbd-41bc-bc2d-0fd7ba282485"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Scissors"",
                    ""type"": ""Button"",
                    ""id"": ""e591a7f8-593e-4f09-a5c2-8fdbd72e941b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2b81c77a-89a9-4694-a193-dbd02a2f6a11"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rock"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e3da744d-5be8-4728-adbf-52de6ec99e24"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Rock"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4fcdc894-013a-49f4-8982-da1dad07ef32"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Paper"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e2eff7a-e73c-4f27-984c-f2f64da7edd5"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Paper"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""40a219de-ac46-4469-8607-2bc5d4e3a055"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Scissors"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""813d9995-b6b6-494a-a157-9fba616b75d8"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Scissors"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""b150f7f4-c96d-4a53-8020-f53f5c6656d7"",
            ""actions"": [
                {
                    ""name"": ""Join"",
                    ""type"": ""Button"",
                    ""id"": ""d47a0e22-8e78-45ab-8d90-9d9f213d0f50"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StartGame"",
                    ""type"": ""Button"",
                    ""id"": ""12290d44-0885-4eab-8e98-36554cdb588c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""89abe4fc-2407-4f0f-97a1-cc2c7011d5ef"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Join"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dcb4e212-35e1-4add-9f66-657f08385017"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Join"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f9326d7-e0c1-4e1d-a143-51291da2e99e"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""StartGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b70237b-9b28-4c84-866c-c6aaed679d6e"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""StartGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
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
        },
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
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Game
        m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
        m_Game_Rock = m_Game.FindAction("Rock", throwIfNotFound: true);
        m_Game_Paper = m_Game.FindAction("Paper", throwIfNotFound: true);
        m_Game_Scissors = m_Game.FindAction("Scissors", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_Join = m_Menu.FindAction("Join", throwIfNotFound: true);
        m_Menu_StartGame = m_Menu.FindAction("StartGame", throwIfNotFound: true);
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

    // Game
    private readonly InputActionMap m_Game;
    private IGameActions m_GameActionsCallbackInterface;
    private readonly InputAction m_Game_Rock;
    private readonly InputAction m_Game_Paper;
    private readonly InputAction m_Game_Scissors;
    public struct GameActions
    {
        private @InputActions m_Wrapper;
        public GameActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Rock => m_Wrapper.m_Game_Rock;
        public InputAction @Paper => m_Wrapper.m_Game_Paper;
        public InputAction @Scissors => m_Wrapper.m_Game_Scissors;
        public InputActionMap Get() { return m_Wrapper.m_Game; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
        public void SetCallbacks(IGameActions instance)
        {
            if (m_Wrapper.m_GameActionsCallbackInterface != null)
            {
                @Rock.started -= m_Wrapper.m_GameActionsCallbackInterface.OnRock;
                @Rock.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnRock;
                @Rock.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnRock;
                @Paper.started -= m_Wrapper.m_GameActionsCallbackInterface.OnPaper;
                @Paper.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnPaper;
                @Paper.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnPaper;
                @Scissors.started -= m_Wrapper.m_GameActionsCallbackInterface.OnScissors;
                @Scissors.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnScissors;
                @Scissors.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnScissors;
            }
            m_Wrapper.m_GameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Rock.started += instance.OnRock;
                @Rock.performed += instance.OnRock;
                @Rock.canceled += instance.OnRock;
                @Paper.started += instance.OnPaper;
                @Paper.performed += instance.OnPaper;
                @Paper.canceled += instance.OnPaper;
                @Scissors.started += instance.OnScissors;
                @Scissors.performed += instance.OnScissors;
                @Scissors.canceled += instance.OnScissors;
            }
        }
    }
    public GameActions @Game => new GameActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_Join;
    private readonly InputAction m_Menu_StartGame;
    public struct MenuActions
    {
        private @InputActions m_Wrapper;
        public MenuActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Join => m_Wrapper.m_Menu_Join;
        public InputAction @StartGame => m_Wrapper.m_Menu_StartGame;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @Join.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnJoin;
                @Join.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnJoin;
                @Join.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnJoin;
                @StartGame.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnStartGame;
                @StartGame.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnStartGame;
                @StartGame.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnStartGame;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Join.started += instance.OnJoin;
                @Join.performed += instance.OnJoin;
                @Join.canceled += instance.OnJoin;
                @StartGame.started += instance.OnStartGame;
                @StartGame.performed += instance.OnStartGame;
                @StartGame.canceled += instance.OnStartGame;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IGameActions
    {
        void OnRock(InputAction.CallbackContext context);
        void OnPaper(InputAction.CallbackContext context);
        void OnScissors(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnJoin(InputAction.CallbackContext context);
        void OnStartGame(InputAction.CallbackContext context);
    }
}
