using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace com.N8Dev.Brackeys.Splitting
{
    [Serializable]
    public class Combining
    {
        //Assignables
        [SerializeField] private Transform Transform;
        
        public void Combine(Vector3 _otherPos, SpriteRenderer _biggerSize, Vector3 _targetPos)
        {
            bool _shouldSpawn = Transform.position.x > _otherPos.x;
            if (_shouldSpawn)
                Object.Instantiate(_biggerSize, _targetPos, Quaternion.identity);
            Object.Destroy(Transform.gameObject);
        }
    }
}