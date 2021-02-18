using com.N8Dev.Brackeys.Effects;
using com.N8Dev.Brackeys.Movement;
using com.N8Dev.Brackeys.Utilities;
using UnityEngine;

namespace com.N8Dev.Brackeys.Sizing
{
    [RequireComponent(typeof(ISizeable), typeof(IMoveable))]
    public class PlayerCombining : MonoBehaviour
    {
        //Assignables
        private ISizeable sizeable;
        private IMoveable moveable;

        //Cooldown
        [SerializeField] private CooldownTimer CooldownTimer;
        
        //Effects
        [SerializeField] private Shake CameraShake;
        [SerializeField] private EffectParticles BiggerSizeParticles;

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
                Instantiate(sizeable.GetBiggerSize(), moveable.GetTargetPosition(), Quaternion.identity);
                Camera.main.ShakeCamera(CameraShake);
                BiggerSizeParticles.Play(moveable.GetTargetPosition());
            }
            Destroy(gameObject);
        }
    }
}