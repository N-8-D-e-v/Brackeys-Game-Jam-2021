using com.N8Dev.Allete.Utilities;
using UnityEngine;

namespace com.N8Dev.Allete.GameData
{
    [DisallowMultipleComponent]
    public class GameState_Player : MonoBehaviour
    {
        private void Awake()
        {
            EventManager.OnSceneLoadStart += GameStateManager.PauseGame;
            EventManager.OnSceneLoadEnd += GameStateManager.StartGame;
            EventManager.OnPlayerMovesRunOut += GameStateManager.PauseGame;
        }

        private void OnDisable()
        {
            EventManager.OnSceneLoadStart -= GameStateManager.PauseGame;
            EventManager.OnSceneLoadEnd -= GameStateManager.StartGame;
            EventManager.OnPlayerMovesRunOut += GameStateManager.PauseGame;
        }
    }
}