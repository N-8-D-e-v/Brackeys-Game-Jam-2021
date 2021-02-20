using TMPro;
using UnityEngine;

namespace com.N8Dev.Allete.UI
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(TextMeshProUGUI))]
    public abstract class UI_UpdateText : MonoBehaviour
    {
        //Text
        private TextMeshProUGUI text;

        private void Awake() => 
            text = GetComponent<TextMeshProUGUI>();

        private void Update() => 
            text.text = GetText();

        protected abstract string GetText();
    }
}