using System;
using com.N8Dev.Brackeys.AudioManagement;
using com.N8Dev.Brackeys.Effects;
using com.N8Dev.Brackeys.GameData;
using com.N8Dev.Brackeys.Movement;
using com.N8Dev.Brackeys.Utilities;
using UnityEngine;

namespace com.N8Dev.Brackeys.Sizing
{
    [RequireComponent(typeof(ISizeable), typeof(IMoveable))]
    public class PlayerCombining : MonoBehaviour
    {
        //Event
        public static event Action OnPlayerCombine;

        //Assignables
        private ISizeable sizeable;
        private IMoveable moveable;

        //Cooldown
        [SerializeField] private CooldownTimer CooldownTimer;
        
        //Effects
        [SerializeField] private Shake CameraShake;
        [SerializeField] private EffectParticles BiggerSizeParticles;
        [SerializeField] private Sound Sound;

        private void Awake()
        {
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
                OnPlayerCombine?.Invoke();
                Instantiate(sizeable.GetBiggerSize(), moveable.GetTargetPosition(), Quaternion.identity);
                
                Camera.main.ShakeCamera(CameraShake);
                BiggerSizeParticles.Play(moveable.GetTargetPosition());
                Sound.Play();
            }
            Destroy(gameObject);
        }
    }
}