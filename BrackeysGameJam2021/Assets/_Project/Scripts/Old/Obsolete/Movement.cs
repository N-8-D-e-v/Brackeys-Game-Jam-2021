using System;
using UnityEngine;

namespace com.N8Dev.Brackeys.Obsolete
{
    [Obsolete]
    [Serializable]
    public class Movement
    {
        //Speed
        [SerializeField] private float Speed;
        
        public Vector2 Move(Vector2 _currentPosition, Vector2 _input) => 
            _currentPosition + _input * Speed;
    }
}