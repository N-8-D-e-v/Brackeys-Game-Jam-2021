using UnityEngine;

namespace com.N8Dev.BrackeysGameJam2021.Skydiving
{
    [RequireComponent(typeof(Rigidbody))]
    public class AirMovementController : MonoBehaviour
    {
        //Input
        private AirMovementInput input;
        
        //Movement
        [SerializeField] private AirMovementVelocity AirMovement;

        private void Awake() => input = new AirMovementInput();

        private void FixedUpdate() => 
            AirMovement.Move(input.GetInput());
    }
}
