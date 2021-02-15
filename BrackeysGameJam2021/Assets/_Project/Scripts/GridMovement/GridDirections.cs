using System;
using UnityEngine;

namespace com.N8Dev.Brackeys.GridMovement
{
    public static class GridDirections
    {
        public static Vector3 GetDirection(Vector3 _dir, Grid _grid)
        {
            if (_dir == Vector3.left)
                return Left(_grid);
            if (_dir == Vector3.right)
                return Right(_grid);
            if (_dir == Vector3.up)
                return Forward(_grid);
            if (_dir == Vector3.down)
                return Back(_grid);
            if (_dir == Vector3.zero)
                return Vector3.zero;
            throw new ArgumentOutOfRangeException();
        }
        
        private static Vector3 TileIncrements(Grid _grid)
        {
            Vector3 _cellSize = _grid.cellSize;
            return new Vector3(_cellSize.x / 2, _cellSize.y / 2, 0f);
        }

        private static Vector3 Left(Grid _grid) => 
            new Vector3(-TileIncrements(_grid).x, TileIncrements(_grid).y, TileIncrements(_grid).z);

        private static Vector3 Right(Grid _grid) => 
            new Vector3(TileIncrements(_grid).x, -TileIncrements(_grid).y, TileIncrements(_grid).z);

        private static Vector3 Forward(Grid _grid) => TileIncrements(_grid);

        private static Vector3 Back(Grid _grid) => -TileIncrements(_grid);
    }
}