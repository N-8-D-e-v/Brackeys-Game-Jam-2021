using System.Collections.Generic;
using com.N8Dev.Brackeys.GridMovement;
using UnityEngine;

namespace com.N8Dev.Brackeys.Splitting
{
    [RequireComponent(typeof(Freezing), typeof(IMovement))]
    public class SplittingController : MonoBehaviour
    {
        //Assignables
        private new Transform transform;
        private Freezing freezing;
        private IMovement movement;
        
        //Knockback
        [SerializeField] private Knockback Knockback;
        [SerializeField] private GridPositioning GridPositioning;

        private void Awake()
        {
            transform = GetComponent<Transform>();
            freezing = GetComponent<Freezing>();
            movement = GetComponent<IMovement>();
        }

        private void OnTriggerEnter2D(Collider2D _collider)
        {
            if (!_collider.TryGetComponent<Slicer>(out Slicer _slicer) || freezing.IsFrozen())
                return;
            Split(_slicer.GetKnockbackDirections());
        }

        private void Split(IEnumerable<Vector3> _knockbackDirections)
        {
            foreach (Vector3 _direction in _knockbackDirections)
                Instantiate(transform, movement.GetTargetPosition(), Quaternion.identity)
                    .GetComponent<SplittingController>().Knock(_direction);
            Destroy(gameObject);
        }

        private void Knock(Vector3 _direction)
        {
            Vector3 _position = GridPositioning.GetNextPosition(transform.position, _direction);
            Knockback.Knock(transform, _position, freezing);
        }
    }
}