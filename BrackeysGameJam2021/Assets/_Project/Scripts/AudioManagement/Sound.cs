using System;
using UnityEngine;

namespace com.N8Dev.Brackeys.AudioManagement
{
    [Serializable]
    public class Sound
    {
        //Sound
        [SerializeField] private string SoundName;

        public void Play() =>
            SoundManager.PlaySound(SoundName);
    }
}