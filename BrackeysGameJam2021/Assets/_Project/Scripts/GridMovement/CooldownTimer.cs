using System;
using com.N8Dev.Brackeys.Utilities;
using UnityEngine;

namespace com.N8Dev.Brackeys.GridMovement
{
    [Serializable]
    public class CooldownTimer
    {
        //Public Fields
        public bool IsCooledDown { private set; get; } = true;

        //Time
        [SerializeField] private float CooldownTime;

        public void StartCooldown()
        {
            IsCooledDown = false;
            this.Invoke(() => IsCooledDown = true, CooldownTime);
        }
    }
}