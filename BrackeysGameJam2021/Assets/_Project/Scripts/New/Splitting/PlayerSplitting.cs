using System.Collections.Generic;
using com.N8Dev.Brackeys.Movement;
using UnityEngine;

namespace com.N8Dev.Brackeys.Splitting
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(IFreezable), typeof(IMoveable))]
    [RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
    public class PlayerSplitting : MonoBehaviour
    {
        //Assignables
        private new Transform transform;
        private IFreezable freezable;
        private IMoveable moveable;

        //Freeze Time
        [Range(0.1f, 1f)] [SerializeField] private float FreezeTime = 0.2f;

        //Splitters
        [SerializeField] private Sprite[] Slicers;

        private void Awake()
        {
            transform = GetComponent<Transform>();
            freezable = GetComponent<IFreezable>();
            moveable = GetComponent<IMoveable>();
        }

        private void OnTriggerStay2D(Collider2D _collider)
        {
            if (freezable.IsFrozen())
                return;
            if (!_collider.TryGetComponent<SpriteRenderer>(out SpriteRenderer _spriteRenderer))
                return;
            for (int _i = 0; _i < Slicers.Length; _i++)
            {
                if (_spriteRenderer.sprite != Slicers[_i])
                    continue;
                if (_spriteRenderer.TryGetComponent<ISlicer>(out ISlicer _slicer))
                    Split(_slicer.GetSliceKnockback());
            }
        }

        private void Split(IReadOnlyList<Vector3> _sliceKnockback)
        {
            for (int _i = 0; _i < _sliceKnockback.Count; _i++)
            {
                PlayerSplitting _splitting = Instantiate(this, moveable.GetTargetPosition(), Quaternion.identity);
                _splitting.freezable.Freeze(FreezeTime);
                _splitting.moveable.Move(_sliceKnockback[_i]);
            }
            Destroy(gameObject);
        }
    }
}