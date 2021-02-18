using DG.Tweening;
using UnityEngine;

namespace com.N8Dev.Brackeys.UI
{
    public abstract class UI_Shake : MonoBehaviour
    {
        //Assignables
        [SerializeField] private Transform Transform;
        
        //Animation
        [Range(0, 100f)] [SerializeField] private float ShakeStrength;
        [Range(0f, 3f)] [SerializeField] private float AnimationTime;

        protected void Shake()
        {
            Transform.DOShakePosition(AnimationTime, ShakeStrength);
            Transform.DOShakeRotation(AnimationTime, ShakeStrength);
        }
    }
}