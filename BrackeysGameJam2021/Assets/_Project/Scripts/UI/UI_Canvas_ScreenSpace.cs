using UnityEngine;

namespace com.N8Dev.Brackeys.UI
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Canvas))]
    public class UI_Canvas_ScreenSpace : MonoBehaviour
    {
        private void Awake() => 
            GetComponent<Canvas>().worldCamera = Camera.main;
    }
}