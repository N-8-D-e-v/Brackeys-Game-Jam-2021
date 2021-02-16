using UnityEngine;

namespace com.N8Dev.Brackeys.GridMovement
{
    public interface IMovement
    {
        public Vector3 GetTargetPosition();

        public Vector3 GetDirection();
    }
}