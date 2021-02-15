using com.N8Dev.Brackeys.Utilities;
using UnityEngine;

namespace com.N8Dev.Brackeys.GridMovement
{
    public class FreezingController : MonoBehaviour
    {
        //Frozen
        private bool isFrozen = false;

        public bool IsFrozen() => isFrozen;
        
        public void Freeze(float _seconds)
        {
            isFrozen = true;
            this.Invoke(() => isFrozen = false, _seconds);
        }
    }
}