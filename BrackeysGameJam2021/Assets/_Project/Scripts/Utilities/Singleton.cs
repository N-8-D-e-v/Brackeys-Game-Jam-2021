using UnityEngine;

namespace com.N8Dev.Brackeys.Utilities
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        //Singleton
        private static T instance;
        
        private void Awake()
        {
            if (!instance)
            {
                instance = this as T;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            Init();
        }

        #region Summary
        /// <summary>
        /// Used in place of Awake() for singleton scripts.
        /// </summary>
        #endregion
        protected virtual void Init() { }
    }
}