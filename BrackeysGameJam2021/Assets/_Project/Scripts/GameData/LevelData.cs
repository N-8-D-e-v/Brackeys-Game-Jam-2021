using com.N8Dev.Brackeys.Movement;
using com.N8Dev.Brackeys.Sizing;
using com.N8Dev.Brackeys.Utilities;
using UnityEngine;

namespace com.N8Dev.Brackeys.GameData
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

        private void Awake()
        {
            timeBeforeRestarting = TimeBeforeRestarting;
            playerMovesRemaining = PlayerMovesAllowed;
            numberOfPlayers = 1;

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

        private static async void PlayerMove()
        {
            playerMovesRemaining -= 1 / (float) numberOfPlayers;
            if (playerMovesRemaining != 0) 
                return;
            EventManager.PlayerMovesRunOut(timeBeforeRestarting);
        }
        
        private static void PlayerSplit() =>
            numberOfPlayers += 1;

        private static void PlayerCombine() => 
            numberOfPlayers -= 1;
    }
}