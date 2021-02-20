using com.N8Dev.Allete.Grids;
using com.N8Dev.Allete.Utilities;
using UnityEngine;

namespace com.N8Dev.Allete.Movement
{
    [DisallowMultipleComponent]
    public abstract class IsometricMovement : MonoBehaviour, IMoveable
    {
        //Assignables
        private new Transform transform;

        //Movement Models
        [Header("Movement Models")]
        [Range(1, 3)] [SerializeField] private int Speed = 1;
        [SerializeField] private Sprite[] Obstacles;
        private Vector3 targetPosition;
        
        //Force Move
        [Header("Force Move")]
        [SerializeField] private CooldownTimer ForceMoveCooldown;

        protected virtual void Awake()
        {
            transform = GetComponent<Transform>();
            targetPosition = transform.position;
        }

        public void Move(Vector3 _direction)
        {
            if (!ForceMoveCooldown.IsCooledDown())
                return;
            Vector3 _nextPosition = GetNextPosition(_direction);
            
            if (CanMove(_nextPosition))
            {
                if (targetPosition == _nextPosition) 
                    return;
                GetSuccessfulMovementView().ApplyMovement(_nextPosition);
                targetPosition = _nextPosition;
            }
            else
            {
                GetUnsuccessfulMovementView().ApplyMovement(_nextPosition);
            }
        }

        public void ForceMove(Vector3 _direction)
        {
            Vector3 _nextPosition = IsometricGrid.GetPosOnGrid
                (targetPosition + IsometricGrid.VectorToDirection(_direction) * Speed);
            targetPosition = _nextPosition;
            GetSuccessfulMovementView().ApplyMovement(_nextPosition);
            ForceMoveCooldown.StartCooldown();
        }

        public Vector3 GetTargetPosition() => targetPosition;

        private Vector3 GetNextPosition(Vector3 _direction) => 
            IsometricGrid.GetPosOnGrid(targetPosition + IsometricGrid.VectorToDirection(_direction) * Speed);

        private bool CanMove(Vector3 _nextPosition) => 
            IsometricGrid.HasTile(_nextPosition) && 
            !IsometricGrid.HasObstacle(_nextPosition, Obstacles);
        
        protected abstract IMovementView GetSuccessfulMovementView();

        protected abstract IMovementView GetUnsuccessfulMovementView();
    }
}