using com.N8Dev.Brackeys.SceneManagement;
using UnityEngine;

namespace com.N8Dev.Brackeys.GameData
{
    [DisallowMultipleComponent]
    public class GameState_Player : MonoBehaviour
    {
        private void Awake()
        {
            SceneManager.OnSceneLoadStart += GameStateManager.PauseGame;
            SceneManager.OnSceneLoadEnd += GameStateManager.StartGame;
        }

        private void OnDisable()
        {
            SceneManager.OnSceneLoadStart -= GameStateManager.PauseGame;
            SceneManager.OnSceneLoadEnd -= GameStateManager.StartGame;
        }
    }
}