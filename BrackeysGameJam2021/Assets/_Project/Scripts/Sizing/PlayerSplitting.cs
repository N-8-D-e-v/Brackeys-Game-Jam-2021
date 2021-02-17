using com.N8Dev.Brackeys.Movement;
using UnityEngine;

namespace com.N8Dev.Brackeys.Sizing
{
    [RequireComponent(typeof(IMoveable))]
    [RequireComponent(typeof(PlayerSizing))]
    public class PlayerSplitting : MonoBehaviour
    {
        //Assignables
        private IMoveable moveable;
        private PlayerSizing playerSizing;

        //Cooldown
        [SerializeField] private CooldownTimer CooldownTimer;

        private void Awake()
        {
            moveable = GetComponent<IMoveable>();
            playerSizing = GetComponent<PlayerSizing>();
        }

        private void OnTriggerEnter2D(Collider2D _collider)
        {
            if (!CooldownTimer.IsCooledDown())
                return;
            if (!_collider.TryGetComponent<ISlicer>(out ISlicer _slicer)) 
                return;
            if (_slicer.GetSize() != playerSizing.GetSize())
                return;
            Slice(_slicer);
            CooldownTimer.StartCooldown();
        }

        private void Slice(ISlicer _slicer)
        {
            Transform _lowerSize = playerSizing.GetLowerSize();
            for (int _i = 0; _i < _slicer.GetSliceKnockback().Length; _i++)
            {
                PlayerSplitting _player = Instantiate
                    (_lowerSize, moveable.GetTargetPosition(), Quaternion.identity)
                    .GetComponent<PlayerSplitting>();
                _player.CooldownTimer.StartCooldown();
                _player.GetComponent<IMoveable>().Move(_slicer.GetSliceKnockback()[_i]);
            }

            Destroy(gameObject);
        }
    }
}