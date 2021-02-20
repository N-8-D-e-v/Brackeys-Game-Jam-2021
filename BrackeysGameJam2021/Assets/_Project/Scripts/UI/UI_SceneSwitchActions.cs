using com.N8Dev.Allete.SceneManagement;
using UnityEngine;

namespace com.N8Dev.Allete.UI
{
    public class UI_SceneSwitchActions : MonoBehaviour
    {
        public void ReloadScene() => 
            SceneManager.LoadCurrentScene();

        public void LoadNextScene() =>
            SceneManager.LoadNextScene();
    }
}