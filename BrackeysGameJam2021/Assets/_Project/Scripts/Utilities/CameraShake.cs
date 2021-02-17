using System;
using DG.Tweening;
using UnityEngine;

namespace com.N8Dev.Brackeys.Utilities
{
    public static class CameraShake
    {
        public static void ShakeCamera(this Camera _camera, Shake _shake)
        {
            Transform _cameraTransform = _camera.transform;
            Vector3 _startPos = _cameraTransform.position;
            _camera.DOShakePosition(_shake.Duration, _shake.Strength);
            _camera.Invoke(() => _cameraTransform.position = _startPos, _shake.Duration);
        }
    }
    
    [Serializable] 
    public struct Shake
    {
        public float Duration;
        public float Strength;
    }
}