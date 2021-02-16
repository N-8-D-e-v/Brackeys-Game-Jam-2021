using System;
using UnityEngine;

namespace com.N8Dev.Brackeys.Utilities
{
    [Serializable]
    public class CooldownTimer
    {
        //Public Fields
        public bool IsCooledDown { private set; get; } = true;

        //Time
        [Range(0.1f, 100f)] [SerializeField] private float CooldownTime = 0.3f;

        public void StartCooldown()
        {
            IsCooledDown = false;
            this.Invoke(() => IsCooledDown = true, CooldownTime);
        }
    }
}