using System;
using com.N8Dev.Brackeys.GridMovement;
using UnityEngine;

namespace com.N8Dev.Brackeys.Splitting
{
    [RequireComponent(typeof(Freezing), typeof(IMovement))]
    public class SizeController : MonoBehaviour
    {
        //Assignables
        private Freezing freezing;
        private IMovement movement;

        //Sizes
        [SerializeField] private CharacterSizes CharacterSizes;

        //Splitting
        [SerializeField] private Splitting Splitting;
        [SerializeField] private Combining Combining;

        private void Awake()
        {
            freezing = GetComponent<Freezing>();
            movement = GetComponent<IMovement>();
        }

        private void OnTriggerEnter2D(Collider2D _collider)
        {
            if (_collider.TryGetComponent<Slicing>(out Slicing _slicer) && !freezing.IsFrozen())
            {
                SpriteRenderer _smallerSize = CharacterSizes.GetSmallerSize();
                if (!_smallerSize)
                {
                    
                    return;
                }

                Splitting.Split(_slicer.GetKnockbackDirections(), _smallerSize, movement.GetTargetPosition());
            }
            else if (_collider.TryGetComponent<SizeController>(out SizeController _sizeController) && !freezing.IsFrozen())
            {
                SpriteRenderer _biggerSize = CharacterSizes.GetBiggerSize();
                if (!_biggerSize)
                    throw new InvalidOperationException();
                Combining.Combine(_sizeController.transform.position, _biggerSize, movement.GetTargetPosition());
            }
        }

        public void Knock(Vector3 _direction) => Splitting.Knock(_direction);
    }
}