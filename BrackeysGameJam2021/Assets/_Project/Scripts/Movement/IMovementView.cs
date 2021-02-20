using UnityEngine;

namespace com.N8Dev.Allete.Movement
{
    public interface IMovementView
    {
        public void ApplyMovement(Vector3 _targetPos);
    }
}