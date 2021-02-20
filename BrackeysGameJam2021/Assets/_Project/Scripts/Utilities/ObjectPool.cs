using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace com.N8Dev.Allete.Utilities
{
    [Serializable]
    public class ObjectPool<T> where T : Component
    {
        //Objects
        [Range(0, 1000)] [SerializeField] private int MaxObjects = 20;
        private readonly Queue<T> pooledObjects;

        public ObjectPool(GameObject _gameObject, T _pooledObject)
        {
            Transform _transform = _gameObject.GetComponent<Transform>();

            pooledObjects = new Queue<T>();
            for (int _i = 0; _i < MaxObjects; _i++)
            {
                T _obj = Object.Instantiate
                    (_pooledObject, Vector3.zero, Quaternion.identity, _transform);
                pooledObjects.Enqueue(_obj);
                _obj.gameObject.SetActive(false);
            }
        }

        public T SpawnObject(float _lifetime)
        {
            if (pooledObjects.Count == 0)
                return null;
            T _obj = pooledObjects.Dequeue();
            _obj.gameObject.SetActive(true);
            this.Invoke(() =>
            {
                _obj.gameObject.SetActive(false);
                pooledObjects.Enqueue(_obj);
            }, _lifetime);
            return _obj;
        }
    }
}