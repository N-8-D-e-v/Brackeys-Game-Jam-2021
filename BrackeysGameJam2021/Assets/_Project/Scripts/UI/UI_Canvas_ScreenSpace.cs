using UnityEngine;

namespace com.N8Dev.Allete.UI
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Canvas))]
    public class UI_Canvas_ScreenSpace : MonoBehaviour
    {
        private void Awake() => 
            GetComponent<Canvas>().worldCamera = Camera.main;
    }
}