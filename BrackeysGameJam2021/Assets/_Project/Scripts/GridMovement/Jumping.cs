using System;
using DG.Tweening;
using UnityEngine;

namespace com.N8Dev.Brackeys.GridMovement
{
    [Serializable]
    public class Jumping
    {
        //Assignables
        public Transform Transform { set; private get; }
        
        //Jumping
        [SerializeField] private float JumpPower;
        [SerializeField] private float JumpDuration;

        public void Jump(Vector3 _targetPos) => 
            Transform.DOJump(_targetPos, JumpPower, 1, JumpDuration);
    }
}