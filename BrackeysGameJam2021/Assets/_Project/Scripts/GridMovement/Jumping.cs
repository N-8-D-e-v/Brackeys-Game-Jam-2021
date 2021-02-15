using System;
using DG.Tweening;
using UnityEngine;

namespace com.N8Dev.Brackeys.GridMovement
{
    [Serializable]
    public class Jumping
    {
        //Jumping
        [SerializeField] private float Power;
        [SerializeField] protected float Duration;

        public void Jump(Transform _transform, Vector3 _targetPos) => 
            _transform.DOJump(_targetPos, Power, 1, Duration);
    }
}