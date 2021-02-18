using com.N8Dev.Brackeys.SceneManagement;
using UnityEngine;

namespace com.N8Dev.Brackeys.GameState
{
    [DisallowMultipleComponent]
    public class PlayGameState : MonoBehaviour
    {
        private void Awake() => SceneManager.OnSceneLoadEnd += GameStateManager.StartGame;
    }
}