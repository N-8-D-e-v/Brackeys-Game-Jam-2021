using System;
using System.Threading.Tasks;
using com.N8Dev.Allete.SceneManagement;

namespace com.N8Dev.Allete.Utilities
{
    public static class EventManager
    {
        //Scene Events
        public static event Action OnSceneLoadStart;
        public static event Action OnSceneLoadEnd;

        public static void SceneLoadStart() =>
            OnSceneLoadStart?.Invoke();

        public static void SceneLoadEnd() =>
            OnSceneLoadEnd?.Invoke();
        
        //Level Events
        public static event Action OnPlayerMovesRunOut;
        public static event Action OnPlayerWin;

        public static async void PlayerMovesRunOut(float _seconds)
        {
            OnPlayerMovesRunOut?.Invoke();
            await Task.Delay(TimeSpan.FromSeconds(_seconds));
            SceneManager.LoadCurrentScene();
        }

        public static void PlayerWin() =>
            OnPlayerWin?.Invoke();
        
        //Player Movement Events
        public static event Action OnPlayerBarrier;

        public static void PlayerBarrier() =>
            OnPlayerBarrier?.Invoke();
    }
}