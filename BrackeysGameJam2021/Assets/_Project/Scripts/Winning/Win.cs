using System;
using com.N8Dev.Brackeys.SceneManagement;
using UnityEngine;

namespace com.N8Dev.Brackeys.Winning
{
    [Serializable]
    public class Win
    {
        //Win Conditions
        [SerializeField] private string PlayerTag = "Player";
        private bool hasWon = false;

        public void CheckWin(GameObject _gameObject)
        {
            if (hasWon || !_gameObject.CompareTag(PlayerTag)) 
                return;
            hasWon = true;
            SceneManager.LoadNextScene();
        }
    }
}