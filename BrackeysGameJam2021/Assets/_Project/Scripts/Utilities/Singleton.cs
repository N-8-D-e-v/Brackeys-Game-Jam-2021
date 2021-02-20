using UnityEngine;

namespace com.N8Dev.Allete.Utilities
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        //Singleton
        protected static T Instance;
        
        private void Awake()
        {
            if (!Instance)
            {
                Instance = this as T;
                DontDestroyOnLoad(gameObject);
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