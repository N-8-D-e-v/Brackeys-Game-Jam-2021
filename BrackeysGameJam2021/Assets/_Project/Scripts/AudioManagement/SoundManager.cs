using System;
using System.Collections.Generic;
using com.N8Dev.Allete.Utilities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace com.N8Dev.Allete.AudioManagement
{
    public class SoundManager : Singleton<SoundManager>
    {
        //Object Pooling
        private static ObjectPool<AudioSource> audioSourcesPool;
        
        //Sounds
        [SerializeField] private SoundContainer[] Sounds;
        private static Dictionary<string, AudioClip> soundsDictionary;
        
        //Sound Cooldown
        private static HashSet<string> audioClipCooldown;
        private const float AUDIO_CLIP_COOLDOWN_TIME = 0.1f;

        protected override void Init()
        {
            AudioSource _audioSource = new GameObject("AudioSource").AddComponent<AudioSource>();
            _audioSource.playOnAwake = false;
            
            audioSourcesPool = new ObjectPool<AudioSource>(gameObject, _audioSource);
            audioClipCooldown = new HashSet<string>();
            
            Destroy(_audioSource.gameObject);

            soundsDictionary = new Dictionary<string, AudioClip>();
            for (int _i = 0; _i < Sounds.Length; _i++)
                soundsDictionary.Add(Sounds[_i].Name, Sounds[_i].AudioClip);
        }

        public static void PlaySound(string _soundName) => 
            PlaySound(_soundName, 0.9f, 1.1f);

        public static void PlaySound(string _soundName, float _minPitch, float _maxPitch)
        {
            if (audioClipCooldown.Contains(_soundName))
                return;
            
            AudioClip _sound = soundsDictionary[_soundName];
            AudioSource _audioSource = audioSourcesPool.SpawnObject(_sound.length);
            if (!_audioSource)
                return;
            
            _audioSource.clip = _sound;
            _audioSource.pitch = Random.Range(_minPitch, _maxPitch);
            _audioSource.Play();

            audioClipCooldown.Add(_soundName);
            Instance.Invoke(() => audioClipCooldown.Remove(_soundName), AUDIO_CLIP_COOLDOWN_TIME);
        }
    }

    [Serializable]
    public struct SoundContainer
    {
        public string Name;
        public AudioClip AudioClip;
    }
}