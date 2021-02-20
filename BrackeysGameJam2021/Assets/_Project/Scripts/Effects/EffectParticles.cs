using System;
using UnityEngine;

namespace com.N8Dev.Allete.Effects
{
    [Serializable]
    public class EffectParticles
    {
        //Particle System
        [SerializeField] private ParticleSystem Particles;

        public void Play(Vector3 _spawnPosition)
        {
            Transform _particlesTransform = Particles.transform;
            _particlesTransform.SetParent(null);
            _particlesTransform.position = _spawnPosition;
            Particles.Play();
        }
    }
}