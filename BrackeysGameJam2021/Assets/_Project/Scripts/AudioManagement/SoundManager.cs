using System;
using System.Collections.Generic;
using com.N8Dev.Brackeys.Utilities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace com.N8Dev.Brackeys.AudioManagement
{
    public class SoundManager : Singleton<SoundManager>
    {
        //Object Pooling
        private static ObjectPool<AudioSource> audioSourcesPool;
        
        //Sounds
        [SerializeField] private SoundContainer[] Sounds;
        private static Dictionary<string, AudioClip> soundsDictionary;

        private void Awake()
        {
            AudioSource _audioSource = new GameObject().AddComponent<AudioSource>();
            _audioSource.playOnAwake = false;
            audioSourcesPool = new ObjectPool<AudioSource>(gameObject, _audioSource);
            
            soundsDictionary = new Dictionary<string, AudioClip>();
            for (int _i = 0; _i < Sounds.Length; _i++)
                soundsDictionary.Add(Sounds[_i].Name, Sounds[_i].AudioClip);
        }

        public static void PlaySound(string _soundName)
        {
            AudioClip _sound = soundsDictionary[_soundName];
            AudioSource _audioSource = audioSourcesPool.SpawnObject(_sound.length);
            if (!_audioSource)
                return;
            
            _audioSource.clip = _sound;
            _audioSource.pitch = Random.Range(0.8f, 1.2f);
            _audioSource.Play();
        }
    }

    [Serializable]
    public struct SoundContainer
    {
        public string Name;
        public AudioClip AudioClip;
    }
}