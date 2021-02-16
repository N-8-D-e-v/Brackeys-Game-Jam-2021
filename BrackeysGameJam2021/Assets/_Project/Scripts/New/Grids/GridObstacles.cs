﻿using UnityEngine;
using UnityEngine.Tilemaps;

namespace com.N8Dev.Brackeys.Grids
{
    public class GridObstacles
    {
        //Tilemap
        private readonly Tilemap tilemap;
        
        //Obstacle Check
        private readonly float checkRadius;
        private readonly Collider2D[] foundObstacles = new Collider2D[10];

        public GridObstacles(Tilemap _tilemap, Vector3 _gridCellSize)
        {
            tilemap = _tilemap;
            checkRadius = Mathf.Min(_gridCellSize.x, _gridCellSize.y);
        }

        public bool HasHazard(Vector3 _pos, Vector3Int _gridPos, Sprite[] _obstacles)
        {
            Physics2D.OverlapCircleNonAlloc(_pos, checkRadius, foundObstacles);
            if (foundObstacles.Length == 0)
                return false;

            for (int _x = 0; _x < foundObstacles.Length; _x++)
            {
                if (tilemap.GetSprite(_gridPos) == _obstacles[_x])
                    return true;
                if (!foundObstacles[_x])
                    break;
                for (int _y = 0; _y < _obstacles.Length; _y++)
                {
                    if (!foundObstacles[_x].TryGetComponent<SpriteRenderer>(out SpriteRenderer _spriteRenderer))
                        continue;
                    if (_spriteRenderer.sprite == _obstacles[_y])
                        return true;
                }
            }
            
            return false;
        }
    }
}