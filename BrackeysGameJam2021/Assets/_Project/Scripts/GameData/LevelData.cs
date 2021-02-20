using System;
using System.Threading.Tasks;
using com.N8Dev.Allete.AudioManagement;
using com.N8Dev.Allete.Movement;
using com.N8Dev.Allete.Sizing;
using com.N8Dev.Allete.Utilities;
using UnityEngine;

namespace com.N8Dev.Allete.GameData
{
    [DisallowMultipleComponent]
    public class LevelData : MonoBehaviour
    {
        //Moves
        [Range(0f, 3f)] [SerializeField] private float TimeBeforeRestarting = 0.5f;
        [Range(1, 100)] [SerializeField] private int PlayerMovesAllowed;
        private static float timeBeforeRestarting;
        private static float playerMovesRemaining;
        
        //Players
        private static int numberOfPlayers = 1;
        
        //Sounds
        [SerializeField] private Sound RunOutOfMovesSound;
        private static Sound runOutOfMovesSound;

        private void Awake()
        {
            timeBeforeRestarting = TimeBeforeRestarting;
            playerMovesRemaining = PlayerMovesAllowed;
            numberOfPlayers = 1;
            runOutOfMovesSound = RunOutOfMovesSound;

            PlayerMovement.OnPlayerMove += PlayerMove;
            PlayerSplitting.OnPlayerSplit += PlayerSplit;
            PlayerCombining.OnPlayerCombine += PlayerCombine;
        }

        private void OnDisable()
        {
            PlayerMovement.OnPlayerMove -= PlayerMove;
            PlayerSplitting.OnPlayerSplit -= PlayerSplit;
            PlayerCombining.OnPlayerCombine -= PlayerCombine;
        }

        public static int GetMovesRemaining() => 
            Mathf.Max(0, (int) playerMovesRemaining);

        private static void PlayerMove()
        {
            playerMovesRemaining -= 1 / (float) numberOfPlayers;
            if (playerMovesRemaining > 0) 
                return;
            EventManager.PlayerMovesRunOut(timeBeforeRestarting);
            runOutOfMovesSound.Play();
        }

        private static async void PlayerSplit()
        {
            //TODO don't hardcode this
            await Task.Delay(TimeSpan.FromSeconds(0.3f));
            numberOfPlayers += 1;
        }

        private static async void PlayerCombine()
        {
            //TODO also don't hardcode this
            await Task.Delay(TimeSpan.FromSeconds(0.3f));
            numberOfPlayers -= 1;
        }
    }
}