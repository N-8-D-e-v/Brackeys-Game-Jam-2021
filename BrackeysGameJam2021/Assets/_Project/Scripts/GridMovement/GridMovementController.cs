using com.N8Dev.Brackeys.Input;
using com.N8Dev.Brackeys.InputSystem;
using com.N8Dev.Brackeys.Utilities;
using DG.Tweening;
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
        [SerializeField] private GridPositioning GridPositioning;
        [SerializeField] private CooldownTimer CooldownTimer;
        [SerializeField] private Jumping Jumping;
        private Vector3 targetPosition;

        private void Awake()
        {
            playerInputs = new PlayerInputs(new Inputs_Player());
            
            transform = GetComponent<Transform>();
            Jumping.Transform = transform;
            targetPosition = transform.position;
        }

        private void Update()
        {
            Vector3 _targetPos = GetNextPosition();
            if (targetPosition != _targetPos)
                Jumping.Jump(_targetPos);
            targetPosition = _targetPos;
        }

        private Vector3 GetNextPosition()
        {
            if (!CanMove()) 
                return targetPosition;
            CooldownTimer.StartCooldown();
            return GridPositioning.GetNextPosition
                (targetPosition, playerInputs.GetInputDirection());
        }

        private bool CanMove() => CooldownTimer.IsCooledDown && playerInputs.IsPressingKey();
    }
}
