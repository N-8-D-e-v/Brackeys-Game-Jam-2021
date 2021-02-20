using System;
using com.N8Dev.Allete.AudioManagement;
using com.N8Dev.Allete.Effects;
using com.N8Dev.Allete.Movement;
using com.N8Dev.Allete.Utilities;
using com.N8Dev.Allete.GameData;
using UnityEngine;

namespace com.N8Dev.Allete.Sizing
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