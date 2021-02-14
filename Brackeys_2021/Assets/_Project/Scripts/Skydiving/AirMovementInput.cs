using UnityEngine;

namespace com.N8Dev.BrackeysGameJam2021.Skydiving
{
    public class AirMovementInput
    {
        //Assignables
        private readonly Input_PlayerMovement input;

        public AirMovementInput()
        {
            input = new Input_PlayerMovement();
            input.Enable();
        }

        public Vector3 GetInput()
        {
            Vector2 _readInput = input.Air.Vector2_Movement.ReadValue<Vector2>().normalized;
            return new Vector3(_readInput.x, 0f, _readInput.y);
        }
    }
}