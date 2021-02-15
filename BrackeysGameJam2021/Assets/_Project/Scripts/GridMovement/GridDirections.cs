using System;
using UnityEngine;

namespace com.N8Dev.Brackeys.GridMovement
{
    [Serializable]
    public class GridDirections
    {
        //Grid
        [SerializeField] private Grid Grid;
        
        public Vector3 GetDirection(Vector3 _dir)
        {
            if (_dir == Vector3.left)
                return Left();
            if (_dir == Vector3.right)
                return Right();
            if (_dir == Vector3.up)
                return Forward();
            if (_dir == Vector3.down)
                return Back();
            if (_dir == Vector3.zero)
                return Vector3.zero;
            throw new ArgumentOutOfRangeException();
        }
        
        private Vector3 TileIncrements()
        {
            Vector3 _cellSize = Grid.cellSize;
            return new Vector3(_cellSize.x / 2, _cellSize.y / 2, 0f);
        }

        private Vector3 Left() => 
            new Vector3(-TileIncrements().x, TileIncrements().y, TileIncrements().z);

        private Vector3 Right() => 
            new Vector3(TileIncrements().x, -TileIncrements().y, TileIncrements().z);

        private Vector3 Forward() => TileIncrements();

        private Vector3 Back() => -TileIncrements();
    }
}