using com.N8Dev.Brackeys.SceneManagement;
using UnityEngine;

namespace com.N8Dev.Brackeys.UI
{
    public class UI_SceneSwitchActions : MonoBehaviour
    {
        public void ReloadScene() => SceneManager.LoadCurrentScene();
    }
}