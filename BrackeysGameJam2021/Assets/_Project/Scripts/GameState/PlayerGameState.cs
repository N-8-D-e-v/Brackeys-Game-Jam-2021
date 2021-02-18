using com.N8Dev.Brackeys.SceneManagement;
using UnityEngine;

namespace com.N8Dev.Brackeys.GameState
{
    [DisallowMultipleComponent]
    public class PlayerGameState : MonoBehaviour
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