using com.N8Dev.Brackeys.Movement;
using com.N8Dev.Brackeys.SceneManagement;
using com.N8Dev.Brackeys.Sizing;
using UnityEngine;

namespace com.N8Dev.Brackeys.GameData
{
    [DisallowMultipleComponent]
    public class LevelData : MonoBehaviour
    {
        //Moves
        [SerializeField] private int PlayerMovesAllowed;
        private static float playerMovesRemaining;
        
        //Players
        private static int numberOfPlayers = 1;

        private void Awake()
        {
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

        public static int GetMovesRemaining() => (int) playerMovesRemaining;

        private static void PlayerMove()
        {
            playerMovesRemaining -= 1 / (float) numberOfPlayers;
            if (playerMovesRemaining == 0)
                SceneManager.LoadCurrentScene();
        }
        
        private static void PlayerSplit() =>
            numberOfPlayers += 1;

        private static void PlayerCombine() => 
            numberOfPlayers -= 1;
    }
}