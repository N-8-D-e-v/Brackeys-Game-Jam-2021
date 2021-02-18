using UnityEngine;

namespace com.N8Dev.Brackeys.Utilities
{
    public class AudioManager : MonoBehaviour
    {
        //Singleton
        private static AudioManager instance;
        
        //Object Pooling
        [SerializeField] private int MaxAudioSources = 10;

        private void Awake()
        {
            
        }
        
    }
}