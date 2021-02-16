using com.N8Dev.Brackeys.Utilities;
using UnityEngine;

namespace com.N8Dev.Brackeys.Movement
{
    public class PlayerFreezing : MonoBehaviour, IFreezable
    {
        //Frozen
        private bool isFrozen;

        public void Freeze(float _seconds)
        {
            isFrozen = true;
            this.Invoke(() => isFrozen = false, _seconds);
        }

        public bool IsFrozen() => isFrozen;
    }
}