using System;
using UnityEngine;

namespace com.N8Dev.BrackeysGameJam2021.Skydiving
{
    public interface IAirMovement
    {
        public abstract void Move(Vector3 _input);
    }
}