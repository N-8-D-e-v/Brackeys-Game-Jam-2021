using System;
using UnityEngine;

namespace com.N8Dev.Brackeys.GridMovement
{
    [Serializable]
    public class Knockback : Jumping
    {
        public void Knock(Transform _transform, Vector3 _targetPos, Freezing _freezing)
        {
            Jump(_transform, _targetPos);
            _freezing.Freeze(Duration);
        }
    }
}