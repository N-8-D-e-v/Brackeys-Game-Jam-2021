using com.N8Dev.Brackeys.GridMovement;
using com.N8Dev.Brackeys.Grids;
using UnityEngine;

namespace com.N8Dev.Brackeys.Movement
{
    public abstract class IsometricMovement : MonoBehaviour, IMoveable
    {
        //Assignables
        private new Transform transform;

        //Stats
        [Range(1, 3)] [SerializeField] private int Speed = 1;
        private Vector3 targetPosition;
        
        //Hazards
        [SerializeField] private Sprite[] Obstacles;

        protected virtual void Awake()
        {
            transform = GetComponent<Transform>();
            Vector3 _position = transform.position;
            transform.position = IsometricGrid.GetPosOnGrid(_position);
            targetPosition = _position;
        }

        protected abstract IMovementView GetSuccessfulMovementView();

        protected abstract IMovementView GetUnsuccessfulMovementView();

        protected void Move(Vector3 _direction)
        {
            Vector3 _nextPosition = IsometricGrid.GetPosOnGrid
                (targetPosition + IsometricGrid.VectorToDirection(_direction) * Speed);
            
            if (IsometricGrid.HasTile(_nextPosition) && !IsometricGrid.HasHazard(_nextPosition, Obstacles))
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

        public Vector3 GetTargetPosition() => targetPosition;
    }
}