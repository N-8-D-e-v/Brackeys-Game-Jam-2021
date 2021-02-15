using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace com.N8Dev.Brackeys.GridMovement
{
    [Serializable]
    public class GridPositioning
    {
        //Assignables
        [SerializeField] private Grid Grid;
        [SerializeField] private Tilemap Tilemap;
        
        //Movement
        [Range(0, 5)] [SerializeField] private int Speed = 1;

        public Vector3 GetNextPosition(Vector3 _currentPos, Vector2 _input)
        {
            Vector3 _direction = GridDirections.GetDirection(_input, Grid);
            Vector3 _targetPos = _currentPos + _direction * Speed;
            Vector3Int _gridPos = Tilemap.WorldToCell(_targetPos);
            return Tilemap.HasTile(_gridPos) ? _targetPos : _currentPos;
        }
    }
}