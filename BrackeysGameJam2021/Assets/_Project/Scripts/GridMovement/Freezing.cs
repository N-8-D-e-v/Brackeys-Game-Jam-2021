using System;
using com.N8Dev.Brackeys.Utilities;
using UnityEngine;

namespace com.N8Dev.Brackeys.GridMovement
{
    public class Freezing : MonoBehaviour
    {
        //Event
        public event Action OnFrozen;
        public event Action OnUnFrozen;
        
        //Frozen
        private bool isFrozen = false;

        public bool IsFrozen() => isFrozen;
        
        public void Freeze(float _seconds)
        {
            OnFrozen?.Invoke();
            isFrozen = true;
            this.Invoke(() =>
            {
                isFrozen = false;
                OnUnFrozen?.Invoke();
            }, _seconds);
        }
    }
}