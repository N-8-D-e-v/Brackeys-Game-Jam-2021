using System;
using com.N8Dev.Brackeys.GridMovement;
using UnityEngine;

namespace com.N8Dev.Brackeys.Splitting
{
    [Serializable]
    public class Knockback : Jumping
    {
        //Freeze
        [Range(0.1f, 1f)] [SerializeField] private float FreezeDuration;
        
        public void Knock(Transform _transform, Vector3 _targetPos, Freezing _freezing)
        {
            _freezing.Freeze(FreezeDuration);
            Jump(_transform, _targetPos);
        }
    }
}