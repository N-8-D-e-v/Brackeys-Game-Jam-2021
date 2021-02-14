using System;
using com.N8Dev.BrackeysGameJam2021.Skydiving;
using UnityEngine;

namespace com.N8Dev.BrackeysGameJam2021.Obsolete
{
    [Obsolete]
    [Serializable]
    public class AirMovementForces : IAirMovement
    {
        //Assignables
        [SerializeField] private Rigidbody Rigidbody;
        
        //Values
        [SerializeField] private float Speed;
        [SerializeField] private float TopSpeed;

        public void Move(Vector3 _input)
        {
            Rigidbody.AddForce(_input * Speed);
            Vector3.ClampMagnitude(Rigidbody.velocity, TopSpeed);
        }
    }
}