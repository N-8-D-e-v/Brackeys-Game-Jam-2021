using System;
using UnityEngine;

namespace com.N8Dev.Brackeys.GridMovement
{
    [Serializable]
    public class GridPositioning
    {
        //Assignables
        [SerializeField] private GridDirections GridDirections;
        [SerializeField] private TilemapCheck TilemapCheck;
        [SerializeField] private HazardCheck HazardCheck;

        //Movement
        [Range(0, 5)] [SerializeField] private int Speed = 1;

        public Vector3 GetNextPosition(Vector3 _currentPos, Vector2 _input)
        {
            Vector3 _targetPos = _currentPos + GridDirections.GetDirection(_input) * Speed;
            return TilemapCheck.HasTile(_targetPos) && !HazardCheck.HasHazard(_targetPos) ? 
                _targetPos : _currentPos;
        }
    }
}