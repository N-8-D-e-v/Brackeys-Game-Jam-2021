using System;
using com.N8Dev.Brackeys.GridMovement;
using DG.Tweening;
using UnityEngine;

namespace com.N8Dev.Brackeys.Movement
{
    //TODO rename to Jumping
    [Serializable]
    public class Jumping : IMovementView
    {
        //Jumping
        [SerializeField] private Transform Transform;
        [Range(0.1f, 1f)] [SerializeField] private float Power = 0.3f;
        [Range(0.1f, 1f)] [SerializeField] private float Duration = 0.3f;

        public void ApplyMovement(Vector3 _targetPos) => 
            Transform.DOJump(_targetPos, Power, 1, Duration);
    }
}