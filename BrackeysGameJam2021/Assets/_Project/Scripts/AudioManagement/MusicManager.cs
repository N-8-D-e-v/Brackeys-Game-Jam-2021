using com.N8Dev.Brackeys.Utilities;
using DG.Tweening;
using UnityEngine;

namespace com.N8Dev.Brackeys.AudioManagement
{
    public class MusicManager : Singleton<MusicManager>
    {
        //Assignables
        private AudioSource audioSource;
        
        //Songs
        [SerializeField] private AudioClip[] Songs;
        
        //Volumes
        private const float MIN_VOLUME = 0f;
        private const float MAX_VOLUME = 1f;

        protected override void Init()
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = Songs[0];
            audioSource.volume = MIN_VOLUME;
            audioSource.loop = true;
            audioSource.Play();
        }

        private void Start() =>
            Fade(MAX_VOLUME, 1f);

        private void Fade(float _volume, float _time) =>
            audioSource.DOFade(_volume, _time);
    }
}