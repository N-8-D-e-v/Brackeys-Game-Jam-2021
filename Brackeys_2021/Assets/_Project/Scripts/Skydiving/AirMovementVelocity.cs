using System;
using UnityEngine;

namespace com.N8Dev.BrackeysGameJam2021.Skydiving
{
    [Serializable]
    public class AirMovementVelocity : IAirMovement
    {
        //Assignables
        [SerializeField] private Rigidbody Rigidbody;
        
        //Values
        [SerializeField] private float Speed;
        [SerializeField] private float Acceleration;

        public void Move(Vector3 _input)
        {
            Vector3 _currentVelocity = Rigidbody.velocity;
            Vector3 _targetVelocity = _input * Speed;
            Vector3 _lerpedVelocity = Vector3.Lerp(_currentVelocity, _targetVelocity, Acceleration);
            Rigidbody.velocity = _lerpedVelocity;
        }
    }
}