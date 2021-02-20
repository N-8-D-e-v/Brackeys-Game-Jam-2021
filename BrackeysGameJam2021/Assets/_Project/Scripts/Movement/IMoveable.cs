using UnityEngine;

namespace com.N8Dev.Allete.Movement
{
    public interface IMoveable
    {
        public Vector3 GetTargetPosition();

        public void Move(Vector3 _direction);
        
        public void ForceMove(Vector3 _direction);
    }
}