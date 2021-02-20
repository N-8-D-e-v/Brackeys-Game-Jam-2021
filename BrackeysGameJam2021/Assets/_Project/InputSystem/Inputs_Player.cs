// GENERATED AUTOMATICALLY FROM 'Assets/_Project/InputSystem/Inputs_Player.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace com.N8Dev.Allete.InputSystem
{
    public class @Inputs_Player : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @Inputs_Player()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Inputs_Player"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""c7a8d62b-0028-41b2-a42d-5dc0b34d2e9a"",
            ""actions"": [
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""dc1a3805-469d-4c3c-9b14-8cb78d211bde"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""61b34d29-b0a8-48d2-9cd1-44d9c4ec4ba5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""502a9c13-6a0a-4aed-8c98-019451603a49"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""d727df45-a021-4214-843f-0f9aaee3e2d9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4674d0cd-a146-4713-81e7-fbb50face271"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed765638-ef3e-46cd-b242-4f7c2f008aa6"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac5dafde-2153-47a8-9704-b5caaff2ff63"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""490afe04-314f-4f6e-a820-69e93d983a14"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1b78ea4-1c07-4e14-8af0-13247a42abed"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""65b54b8d-2afd-4494-b056-91325a368e14"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ffbf68d-cea2-447e-91a0-7bcf21781673"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20e14108-d8bc-4005-9e06-249a4f5fdcb8"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Movement
            m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
            m_Movement_Left = m_Movement.FindAction("Left", throwIfNotFound: true);
            m_Movement_Right = m_Movement.FindAction("Right", throwIfNotFound: true);
            m_Movement_Up = m_Movement.FindAction("Up", throwIfNotFound: true);
            m_Movement_Down = m_Movement.FindAction("Down", throwIfNotFound: true);
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

        // Movement
        private readonly InputActionMap m_Movement;
        private IMovementActions m_MovementActionsCallbackInterface;
        private readonly InputAction m_Movement_Left;
        private readonly InputAction m_Movement_Right;
        private readonly InputAction m_Movement_Up;
        private readonly InputAction m_Movement_Down;
        public struct MovementActions
        {
            private @Inputs_Player m_Wrapper;
            public MovementActions(@Inputs_Player wrapper) { m_Wrapper = wrapper; }
            public InputAction @Left => m_Wrapper.m_Movement_Left;
            public InputAction @Right => m_Wrapper.m_Movement_Right;
            public InputAction @Up => m_Wrapper.m_Movement_Up;
            public InputAction @Down => m_Wrapper.m_Movement_Down;
            public InputActionMap Get() { return m_Wrapper.m_Movement; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
            public void SetCallbacks(IMovementActions instance)
            {
                if (m_Wrapper.m_MovementActionsCallbackInterface != null)
                {
                    @Left.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnLeft;
                    @Left.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnLeft;
                    @Left.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnLeft;
                    @Right.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnRight;
                    @Right.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnRight;
                    @Right.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnRight;
                    @Up.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnUp;
                    @Up.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnUp;
                    @Up.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnUp;
                    @Down.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnDown;
                    @Down.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnDown;
                    @Down.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnDown;
                }
                m_Wrapper.m_MovementActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Left.started += instance.OnLeft;
                    @Left.performed += instance.OnLeft;
                    @Left.canceled += instance.OnLeft;
                    @Right.started += instance.OnRight;
                    @Right.performed += instance.OnRight;
                    @Right.canceled += instance.OnRight;
                    @Up.started += instance.OnUp;
                    @Up.performed += instance.OnUp;
                    @Up.canceled += instance.OnUp;
                    @Down.started += instance.OnDown;
                    @Down.performed += instance.OnDown;
                    @Down.canceled += instance.OnDown;
                }
            }
        }
        public MovementActions @Movement => new MovementActions(this);
        public interface IMovementActions
        {
            void OnLeft(InputAction.CallbackContext context);
            void OnRight(InputAction.CallbackContext context);
            void OnUp(InputAction.CallbackContext context);
            void OnDown(InputAction.CallbackContext context);
        }
    }
}
