using com.N8Dev.Allete.SceneManagement.Transitions;
using com.N8Dev.Allete.Utilities;
using UnityEngine;

namespace com.N8Dev.Allete.SceneManagement
{
    [DisallowMultipleComponent]
    public class SceneManager : Singleton<SceneManager>
    {
        //Transition
        [SerializeField] private FadeTransition SceneTransition;
        private static SceneTransition transition;
        private static bool isTransitioning = false;
        
        //Target Scene
        private static int targetScene;

        protected override void Init()
        {
            transition = SceneTransition;
            transition.OnSceneTransitionStart += EventManager.SceneLoadStart;
            transition.OnSceneTransitionStart += () => isTransitioning = true;
            transition.OnSceneTransitionMiddle += LoadScene;
            transition.OnSceneTransitionEnd += EventManager.SceneLoadEnd;
            transition.OnSceneTransitionEnd += () => isTransitioning = false;
        }

        private void Start() =>
            EventManager.SceneLoadEnd();

        public static void LoadCurrentScene()
        {
            if (isTransitioning)
                return;
            targetScene = GetCurrentScene();
            transition.StartTransition();
        }

        public static void LoadNextScene()
        {
            if (isTransitioning)
                return;
            targetScene = GetCurrentScene() + 1;
            transition.StartTransition();
        }

        private static int GetCurrentScene() => 
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;

        private static void LoadScene() => 
            UnityEngine.SceneManagement.SceneManager.LoadScene(targetScene);
    }
}