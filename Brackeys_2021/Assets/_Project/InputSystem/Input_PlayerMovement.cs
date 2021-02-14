// GENERATED AUTOMATICALLY FROM 'Assets/_Project/InputSystem/Input_PlayerMovement.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Input_PlayerMovement : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Input_PlayerMovement()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input_PlayerMovement"",
    ""maps"": [
        {
            ""name"": ""Air"",
            ""id"": ""3e3a3a42-5f4a-446f-8b21-d1832026024d"",
            ""actions"": [
                {
                    ""name"": ""Vector2_Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""061b34af-35e2-4960-8c7c-75eb16aed263"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""01c915de-c4f9-4432-8bda-0b371ada9a6f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vector2_Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3412605c-c788-4be8-af10-3aabb3b194ce"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vector2_Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7de09d55-93c3-4fa5-b195-1ea7f91c6919"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vector2_Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d8831611-6467-4124-91ef-130ce0966cc2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vector2_Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""17239d90-ee23-478a-b362-95b19ca14002"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vector2_Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""d940d58a-7e78-4181-819f-fd4d00dbf1a6"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vector2_Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""379844ae-f4cb-4fb9-b3e2-2aa87b5bd1eb"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vector2_Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c4ec9e6f-bc21-4d57-b27d-3e3312deec65"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vector2_Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""19e39398-f14d-4495-b93d-20d43a03c2d1"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vector2_Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""cf571819-e998-43a1-a684-2d45a3ec11c6"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vector2_Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Air
        m_Air = asset.FindActionMap("Air", throwIfNotFound: true);
        m_Air_Vector2_Movement = m_Air.FindAction("Vector2_Movement", throwIfNotFound: true);
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

    // Air
    private readonly InputActionMap m_Air;
    private IAirActions m_AirActionsCallbackInterface;
    private readonly InputAction m_Air_Vector2_Movement;
    public struct AirActions
    {
        private @Input_PlayerMovement m_Wrapper;
        public AirActions(@Input_PlayerMovement wrapper) { m_Wrapper = wrapper; }
        public InputAction @Vector2_Movement => m_Wrapper.m_Air_Vector2_Movement;
        public InputActionMap Get() { return m_Wrapper.m_Air; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AirActions set) { return set.Get(); }
        public void SetCallbacks(IAirActions instance)
        {
            if (m_Wrapper.m_AirActionsCallbackInterface != null)
            {
                @Vector2_Movement.started -= m_Wrapper.m_AirActionsCallbackInterface.OnVector2_Movement;
                @Vector2_Movement.performed -= m_Wrapper.m_AirActionsCallbackInterface.OnVector2_Movement;
                @Vector2_Movement.canceled -= m_Wrapper.m_AirActionsCallbackInterface.OnVector2_Movement;
            }
            m_Wrapper.m_AirActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Vector2_Movement.started += instance.OnVector2_Movement;
                @Vector2_Movement.performed += instance.OnVector2_Movement;
                @Vector2_Movement.canceled += instance.OnVector2_Movement;
            }
        }
    }
    public AirActions @Air => new AirActions(this);
    public interface IAirActions
    {
        void OnVector2_Movement(InputAction.CallbackContext context);
    }
}
