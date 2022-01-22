// GENERATED AUTOMATICALLY FROM 'Assets/Input Actions/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using Object = UnityEngine.Object;

namespace Generated
{
    public class PlayerControls : IInputActionCollection, IDisposable
    {

        // Gameplay
        private readonly InputActionMap m_Gameplay;
        private readonly InputAction m_Gameplay_Position;
        private readonly InputAction m_Gameplay_Press;
        private IGameplayActions m_GameplayActionsCallbackInterface;
        public PlayerControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""501104c6-217b-4c0b-a174-d2cf5d1d6a20"",
            ""actions"": [
                {
                    ""name"": ""Position"",
                    ""type"": ""Value"",
                    ""id"": ""c19c2a2d-c48a-459a-813b-4f40dd11f15a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Press"",
                    ""type"": ""Button"",
                    ""id"": ""142ba38d-cfa0-4b19-a4ea-498ebb97f358"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1a64feeb-e75c-495a-a7d6-a7ee1b40cc1f"",
                    ""path"": ""<Pointer>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""809b47e5-1a9c-496e-8975-5b9b96f9ac9e"",
                    ""path"": ""<Pointer>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Gameplay
            m_Gameplay = asset.FindActionMap("Gameplay", true);
            m_Gameplay_Position = m_Gameplay.FindAction("Position", true);
            m_Gameplay_Press = m_Gameplay.FindAction("Press", true);
        }

        public InputActionAsset asset { get; }

        public GameplayActions Gameplay => new GameplayActions(this);

        public void Dispose() => Object.Destroy(asset);

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

        public bool Contains(InputAction action) => asset.Contains(action);

        public IEnumerator<InputAction> GetEnumerator() => asset.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Enable() => asset.Enable();

        public void Disable() => asset.Disable();

        public struct GameplayActions
        {
            private readonly PlayerControls m_Wrapper;
            public GameplayActions(PlayerControls wrapper) => m_Wrapper = wrapper;

            public InputAction Position => m_Wrapper.m_Gameplay_Position;

            public InputAction Press => m_Wrapper.m_Gameplay_Press;

            public InputActionMap Get() => m_Wrapper.m_Gameplay;
            public void Enable() => Get().Enable();
            public void Disable() => Get().Disable();

            public bool enabled => Get().enabled;

            public static implicit operator InputActionMap(GameplayActions set) => set.Get();
            public void SetCallbacks(IGameplayActions instance)
            {
                if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
                {
                    Position.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPosition;
                    Position.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPosition;
                    Position.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPosition;
                    Press.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPress;
                    Press.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPress;
                    Press.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPress;
                }
                m_Wrapper.m_GameplayActionsCallbackInterface = instance;
                if (instance != null)
                {
                    Position.started += instance.OnPosition;
                    Position.performed += instance.OnPosition;
                    Position.canceled += instance.OnPosition;
                    Press.started += instance.OnPress;
                    Press.performed += instance.OnPress;
                    Press.canceled += instance.OnPress;
                }
            }
        }

        public interface IGameplayActions
        {
            void OnPosition(InputAction.CallbackContext context);
            void OnPress(InputAction.CallbackContext context);
        }
    }
}