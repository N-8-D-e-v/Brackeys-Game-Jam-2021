using System;
using UnityEngine;

namespace com.N8Dev.Brackeys.AudioManagement
{
    [Serializable]
    public class Sound
    {
        //Sound
        [SerializeField] private string SoundName;
        [SerializeField] private bool UseRandomPitch = true;

        public void Play()
        {
            if (UseRandomPitch)
                SoundManager.PlaySound(SoundName);
            else
                SoundManager.PlaySound(SoundName, 1f, 1f);
        }
    }
}