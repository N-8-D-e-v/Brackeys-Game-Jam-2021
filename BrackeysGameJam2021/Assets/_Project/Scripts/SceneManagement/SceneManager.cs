using System;
using com.N8Dev.Brackeys.SceneManagement.Transitions;
using com.N8Dev.Brackeys.Utilities;
using UnityEngine;

namespace com.N8Dev.Brackeys.SceneManagement
{
    [DisallowMultipleComponent]
    public class SceneManager : MonoBehaviour
    {
        //Singleton
        private static SceneManager instance;

        //Transition
        [SerializeField] private FadeTransition SceneTransition;
        private static SceneTransition transition;
        private static bool isTransitioning = false;
        
        //Target Scene
        private static int targetScene;

        private void Awake()
        {
            if (!instance)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
                return;
            }
            
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