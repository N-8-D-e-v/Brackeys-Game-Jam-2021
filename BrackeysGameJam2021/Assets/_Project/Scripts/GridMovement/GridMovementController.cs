using com.N8Dev.Brackeys.Input;
using com.N8Dev.Brackeys.InputSystem;
using com.N8Dev.Brackeys.Utilities;
using UnityEngine;

namespace com.N8Dev.Brackeys.GridMovement
{
    public class GridMovementController : MonoBehaviour
    {
        //Assignables
        private new Transform transform;
        
        //Inputs
        private PlayerInputs playerInputs;
        
        //Movement
        [SerializeField] private GridMovement GridMovement = new GridMovement();
        private Vector3 targetPosition;
        private Vector3 velocity;
        
        //Cooldown
        [SerializeField] private float Cooldown = 0.1f;
        private bool canMove = true;

        private void Awake()
        {
            transform = GetComponent<Transform>();
            playerInputs = new PlayerInputs(new Inputs_Player());
            targetPosition = transform.position;
        }

        private void Update()
        {
            targetPosition = GetNextPosition();
            transform.position = Vector3.SmoothDamp
                (transform.position, targetPosition, ref velocity, Cooldown);
        }

        private Vector3 GetNextPosition()
        {
            if (!canMove || !playerInputs.IsPressingKey()) 
                return targetPosition;
            canMove = false;
            this.Invoke(() => canMove = true, Cooldown);
            return GridMovement.Move(targetPosition, playerInputs.GetInputDirection());
        }
    }
}
