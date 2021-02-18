using System;
using com.N8Dev.Brackeys.SceneManagement.Transitions;
using UnityEngine;

namespace com.N8Dev.Brackeys.SceneManagement
{
    public class SceneManager : MonoBehaviour
    {
        //Singleton
        private static SceneManager instance;
        
        //Events
        public static event Action OnSceneLoadStart; 
        public static event Action OnSceneLoadEnd; 
        
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
            else if (instance != this)
            {
                Destroy(gameObject);
                return;
            }
            
            transition = SceneTransition;
            transition.OnSceneTransitionStart += OnSceneLoadStart;
            transition.OnSceneTransitionStart += () => isTransitioning = true;
            transition.OnSceneTransitionMiddle += LoadScene;
            transition.OnSceneTransitionEnd += OnSceneLoadEnd;
            transition.OnSceneTransitionEnd += () => isTransitioning = false;
        }
        
        private void Start() => OnSceneLoadEnd?.Invoke();

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