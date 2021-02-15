using com.N8Dev.Brackeys.Input;
using com.N8Dev.Brackeys.InputSystem;
using UnityEngine;

namespace com.N8Dev.Brackeys.GridMovement
{
    [RequireComponent(typeof(Freezing), typeof(GridPositioning))]
    public class GridMovementController : MonoBehaviour
    {
        //Assignables
        private new Transform transform;
        private Freezing freezing;
        private GridPositioning gridPositioning;
        
        //Inputs
        private PlayerInputs playerInputs;
        
        //Movement
        [SerializeField] private CooldownTimer CooldownTimer;
        [SerializeField] private Jumping Jumping;
        private Vector3 targetPosition;

        private void Awake()
        {
            playerInputs = new PlayerInputs(new Inputs_Player());
            transform = GetComponent<Transform>();
            freezing = GetComponent<Freezing>();
            gridPositioning = GetComponent<GridPositioning>();
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
                return gridPositioning.GetNextPosition(targetPosition, playerInputs.GetInputDirection());
            }
            return targetPosition;
        }
    }
}
