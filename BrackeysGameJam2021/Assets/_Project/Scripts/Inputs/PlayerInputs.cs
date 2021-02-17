using System;
using com.N8Dev.Brackeys.InputSystem;
using UnityEngine;

namespace com.N8Dev.Brackeys.Inputs
{
    [Serializable]
    public class PlayerInputs
    {
        //Assignables
        private readonly Inputs_Player inputs;

        public PlayerInputs(Inputs_Player _inputs)
        {
            inputs = _inputs;
            inputs.Enable();
        }

        public void Enable() => inputs.Enable();

        public void Disable() => inputs.Disable();

        public Vector2 GetInputDirection()
        {
            if (inputs.Movement.Left.triggered)
                return Vector2.left;

            if (inputs.Movement.Right.triggered)
                return Vector2.right;

            if (inputs.Movement.Up.triggered)
                return Vector2.up;

            return inputs.Movement.Down.triggered ? Vector2.down : Vector2.zero;
        }

        public bool IsPressingKey() => 
            inputs.Movement.Left.triggered || 
            inputs.Movement.Right.triggered || 
            inputs.Movement.Up.triggered || 
            inputs.Movement.Down.triggered;
    }
}