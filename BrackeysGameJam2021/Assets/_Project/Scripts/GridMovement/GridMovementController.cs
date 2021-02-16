using com.N8Dev.Brackeys.Input;
using com.N8Dev.Brackeys.InputSystem;
using com.N8Dev.Brackeys.Utilities;
using UnityEngine;

namespace com.N8Dev.Brackeys.GridMovement
{
    [RequireComponent(typeof(Freezing))]
    public class GridMovementController : MonoBehaviour, IMovement
    {
        //Assignables
        private new Transform transform;
        private Freezing freezing;
        
        //Inputs
        private PlayerInputs playerInputs;
        
        //Movement
        [SerializeField] private CooldownTimer CooldownTimer;
        [SerializeField] private Jumping Jumping;
        [SerializeField] private GridPositioning GridPositioning;
        private Vector3 targetPosition;

        private void Awake()
        {
            playerInputs = new PlayerInputs(new Inputs_Player());
            transform = GetComponent<Transform>();
            freezing = GetComponent<Freezing>();
            freezing.OnUnFrozen += () => targetPosition = transform.position;
            targetPosition = transform.position;
        }

        private void Update()
        {
            if (freezing.IsFrozen())
                return;
            Move();
        }

        private void Move()
        {
            Vector3 _targetPos = GetNextPosition();
            if (targetPosition != _targetPos)
                Jumping.Jump(transform, _targetPos);
            targetPosition = _targetPos;
        }

        private Vector3 GetNextPosition()
        {
            if (CooldownTimer.IsCooledDown && playerInputs.IsPressingKey())
            {
                CooldownTimer.StartCooldown();
                return GridPositioning.GetNextPosition(targetPosition, playerInputs.GetInputDirection());
            }
            return targetPosition;
        }

        public Vector3 GetTargetPosition() => targetPosition;

        public Vector3 GetDirection() => playerInputs.GetInputDirection();
    }
}
