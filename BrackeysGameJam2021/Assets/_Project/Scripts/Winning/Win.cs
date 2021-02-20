using System;
using com.N8Dev.Allete.AudioManagement;
using com.N8Dev.Allete.SceneManagement;
using UnityEngine;

namespace com.N8Dev.Allete.Winning
{
    [Serializable]
    public class Win
    {
        //Win Conditions
        [SerializeField] private string PlayerTag = "Player";
        private bool hasWon = false;
        
        //Sound
        [SerializeField] private Sound Sound;

        public void CheckWin(GameObject _gameObject)
        {
            if (hasWon || !_gameObject.CompareTag(PlayerTag)) 
                return;
            hasWon = true;
            Sound.Play();
            SceneManager.LoadNextScene();
        }
    }
}