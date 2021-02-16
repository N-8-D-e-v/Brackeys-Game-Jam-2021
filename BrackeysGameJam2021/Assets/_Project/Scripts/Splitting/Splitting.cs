using System;
using System.Collections.Generic;
using com.N8Dev.Brackeys.GridMovement;
using UnityEngine;
using Object = UnityEngine.Object;

namespace com.N8Dev.Brackeys.Splitting
{
    [Serializable]
    public class Splitting
    {
        //Assignables
        [Header("Assignables")]
        [SerializeField] private Freezing Freezing;
        [SerializeField] private Transform Transform;

        //Knockback
        [Header("Knockback")]
        [SerializeField] private Knockback Knockback;
        [SerializeField] private GridPositioning GridPositioning;

        public void Split(IEnumerable<Vector3> _knockbackDirections, SpriteRenderer _smallerSize, Vector3 _targetPos)
        {
            foreach (Vector3 _direction in _knockbackDirections)
            {
                SizeController _sizeController = Object.Instantiate
                        (_smallerSize, _targetPos, Quaternion.identity)
                    .GetComponent<SizeController>();
                _sizeController.Knock(_direction);
            }
            Object.Destroy(Transform.gameObject);
        }

        public void Knock(Vector3 _direction)
        {
            Vector3 _position = GridPositioning.GetNextPosition(Transform.position, _direction);
            Knockback.Knock(Transform, _position, Freezing);
        }
    }
}