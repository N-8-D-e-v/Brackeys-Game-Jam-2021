using System;
using com.N8Dev.Brackeys.Effects;
using com.N8Dev.Brackeys.GameData;
using com.N8Dev.Brackeys.Utilities;
using com.N8Dev.Brackeys.Movement;
using UnityEngine;

namespace com.N8Dev.Brackeys.Sizing
{
    [RequireComponent(typeof(IMoveable))]
    [RequireComponent(typeof(ISizeable))]
    public class PlayerSplitting : MonoBehaviour
    {
        //Event
        public static event Action OnPlayerSplit; 
        
        //Assignables
        private IMoveable moveable;
        private ISizeable sizeable;

        //Cooldown
        [SerializeField] private CooldownTimer CooldownTimer;
        
        //Effects
        [SerializeField] private Shake CameraShake;
        [SerializeField] private EffectParticles SmallerSizeParticles;

        private void Awake()
        {
            moveable = GetComponent<IMoveable>();
            sizeable = GetComponent<PlayerSizeable>();
        }

        private void OnTriggerEnter2D(Collider2D _collider)
        {
            if (!CooldownTimer.IsCooledDown())
                return;
            if (!_collider.TryGetComponent<ISlicer>(out ISlicer _slicer)) 
                return;
            if (_slicer.GetSize() != sizeable.GetSize())
                return;
            Slice(_slicer);
            CooldownTimer.StartCooldown();
        }

        private void Slice(ISlicer _slicer)
        {
            OnPlayerSplit?.Invoke();
            
            Camera.main.ShakeCamera(CameraShake);
            SmallerSizeParticles.Play(moveable.GetTargetPosition());

            Transform _lowerSize = sizeable.GetLowerSize();
            for (int _i = 0; _i < _slicer.GetSliceKnockback().Length; _i++)
            {
                PlayerSplitting _player = Instantiate
                    (_lowerSize, moveable.GetTargetPosition(), Quaternion.identity)
                    .GetComponent<PlayerSplitting>();
                
                _player.CooldownTimer.StartCooldown();
                IMoveable _playerMoveable = _player.GetComponent<IMoveable>();
                _playerMoveable.ForceMove(_slicer.GetSliceKnockback()[_i]);
            }

            Destroy(gameObject);
        }
    }
}