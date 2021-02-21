using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace com.N8Dev.Allete.SceneManagement.Transitions
{
    [Serializable]
    public class FadeTransition : SceneTransition
    {
        //Graphic
        [SerializeField] private Image Panel;
        
        //Animation
        [SerializeField] private float TransitionLength;

        protected override float GetTransitionAnimationLength() => TransitionLength;

        protected override void AnimateFirstHalfTransition() => 
            Panel.DOFade(1f, GetTransitionAnimationLength() / 2);

        protected override void AnimateSecondHalfTransition() => 
            Panel.DOFade(0f, GetTransitionAnimationLength() / 2);
    }
}