using com.N8Dev.Allete.Utilities;
using UnityEngine;

namespace com.N8Dev.Allete.Effects
{
    [RequireComponent(typeof(ParticleSystem))]
    public class PlayerWinParticles : MonoBehaviour
    {
        //Assignables
        private ParticleSystem particles;

        private void Awake()
        {
            particles = GetComponent<ParticleSystem>();
            EventManager.OnPlayerWin += Play;
        }

        private void OnDisable() =>
            EventManager.OnPlayerWin -= Play;

        private void Play() =>
            particles.Play();
    }
}