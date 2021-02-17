using System;
using com.N8Dev.Brackeys.Movement;
using com.N8Dev.Brackeys.Utilities;
using UnityEngine;

namespace com.N8Dev.Brackeys.Sizing
{
    [RequireComponent(typeof(ISizeable), typeof(IMoveable))]
    public class PlayerCombining : MonoBehaviour
    {
        //Assignables
        private new Transform transform;
        private ISizeable sizeable;
        private IMoveable moveable;
        
        //Cooldown
        [SerializeField] private CooldownTimer CooldownTimer;
        
        //Camera Shake
        [SerializeField] private Shake CameraShake;

        private void Awake()
        {
            transform = GetComponent<Transform>();
            sizeable = GetComponent<ISizeable>();
            moveable = GetComponent<IMoveable>();
            CooldownTimer.StartCooldown();
        }
        
        private void OnTriggerEnter2D(Collider2D _collider)
        {
            if (!CooldownTimer.IsCooledDown())
                return;
            if (!_collider.TryGetComponent<ISizeable>(out ISizeable _otherSizeable))
                return;
            if (_otherSizeable.GetSize() != sizeable.GetSize())
                return;
            if (sizeable.GetID() > _otherSizeable.GetID())
            {
                Instantiate(sizeable.GetBiggerSize(), moveable.GetTargetPosition(), Quaternion.identity);
                Camera.main.ShakeCamera(CameraShake);
            }
            Destroy(gameObject);
        }
    }
}