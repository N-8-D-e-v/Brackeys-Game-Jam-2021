
using com.N8Dev.Brackeys.Utilities;
using UnityEngine;

namespace com.N8Dev.Brackeys.GameData
{
    [DisallowMultipleComponent]
    public class GameState_Player : Singleton<GameState_Player>
    {
        protected override void Init()
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