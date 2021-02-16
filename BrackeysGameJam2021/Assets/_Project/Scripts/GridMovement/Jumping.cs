using System;
using DG.Tweening;
using UnityEngine;

namespace com.N8Dev.Brackeys.GridMovement
{
    [Serializable]
    public class Jumping
    {
        //Jumping
        [Range(0.1f, 1f)] [SerializeField] private float Power;
        [Range(0.1f, 1f)] [SerializeField] private float Duration;

        public void Jump(Transform _transform, Vector3 _targetPos) => 
            _transform.DOJump(_targetPos, Power, 1, Duration);
    }
}