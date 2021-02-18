using System;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace com.N8Dev.Brackeys.SceneManagement.Transitions
{
    [Serializable]
    public class FadeTransition : SceneTransition
    {
        //Graphic
        [SerializeField] private Image Panel;
        
        //Animation
        [SerializeField] private float TransitionLength;

        protected override float GetTransitionAnimationLength() => TransitionLength;

        protected override async void AnimateTransition()
        {
            Panel.DOFade(1f, GetTransitionAnimationLength() / 2);
            await Task.Delay(TimeSpan.FromSeconds(GetTransitionAnimationLength() / 2));
            Panel.DOFade(0f, GetTransitionAnimationLength() / 2);
        }
    }
}