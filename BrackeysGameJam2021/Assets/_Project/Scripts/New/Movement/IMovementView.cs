using UnityEngine;

namespace com.N8Dev.Brackeys.Movement
{
    public interface IMovementView
    {
        public void ApplyMovement(Vector3 _targetPos);
    }
}