using System;
using com.N8Dev.Allete.AudioManagement;
using com.N8Dev.Allete.Effects;
using com.N8Dev.Allete.Utilities;
using DG.Tweening;
using UnityEngine;

namespace com.N8Dev.Allete.Movement
{
    [Serializable]
    public class Barrier : IMovementView
    {
        //Barrier
        [Header("Barrier")]
        [SerializeField] private Transform Transform;
        [Range(0.1f, 1f)] [SerializeField] private float Duration = 0.1f;
        
        //Camera Shake
        [Header("Camera Shake")]
        [SerializeField] private Shake CameraShake;
        
        //Sound
        [Header("Sound")]
        [SerializeField] private Sound Sound;
        
        public void ApplyMovement(Vector3 _targetPos)
        {
            Vector3 _position = Transform.position;
            Vector3 _edge = _position + (_targetPos - _position) / 4;
            Vector3[] _path = {_edge, _position};
            Transform.DOPath(_path, Duration);
            
            Camera.main.ShakeCamera(CameraShake);
            Sound.Play();
            EventManager.PlayerBarrier();
        }
    }
}