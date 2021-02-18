using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace com.N8Dev.Brackeys.UI
{
    public class UI_ResizeOnMouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        //Assignables
        private new Transform transform;
        
        //Animation
        [Range(0f, 3f)] [SerializeField] private float LargerScale = 1.25f;
        [Range(0f, 1f)] [SerializeField] private float AnimationTime = 0.01f;

        private void Awake() => 
            transform = GetComponent<Transform>();
        
        public void OnPointerEnter(PointerEventData _eventData) => 
            transform.DOScale(Vector3.one * LargerScale, AnimationTime);

        public void OnPointerExit(PointerEventData _eventData) => 
            transform.DOScale(Vector3.one, AnimationTime);
    }
}