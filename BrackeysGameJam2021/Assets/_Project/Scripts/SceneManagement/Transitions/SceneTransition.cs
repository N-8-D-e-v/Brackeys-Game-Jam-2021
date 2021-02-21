using System;
using com.N8Dev.Allete.Utilities;

namespace com.N8Dev.Allete.SceneManagement.Transitions
{
    [Serializable]
    public abstract class SceneTransition
    {
        //Events
        public event Action OnSceneTransitionStart;
        public event Action OnSceneTransitionMiddle;
        public event Action OnSceneTransitionEnd;

        protected abstract float GetTransitionAnimationLength();

        public void FirstHalfTransition()
        {
            OnSceneTransitionStart?.Invoke();
            AnimateFirstHalfTransition();
            if (!(OnSceneTransitionMiddle is null))
                this.Invoke(OnSceneTransitionMiddle, GetTransitionAnimationLength() / 2);
        }

        public void SecondHalfTransition()
        {
            AnimateSecondHalfTransition();
            if (!(OnSceneTransitionEnd is null))
                this.Invoke(OnSceneTransitionEnd, GetTransitionAnimationLength());
        }

        protected abstract void AnimateFirstHalfTransition();

        protected abstract void AnimateSecondHalfTransition();
    }
}