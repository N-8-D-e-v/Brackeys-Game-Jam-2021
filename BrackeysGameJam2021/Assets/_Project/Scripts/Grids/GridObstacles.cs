using UnityEngine;
using UnityEngine.Tilemaps;

namespace com.N8Dev.Allete.Grids
{
    public class GridObstacles
    {
        //Tilemap
        private readonly Tilemap tilemap;
        
        //Obstacle Check
        private readonly float checkRadius;

        public GridObstacles(Tilemap _tilemap, Vector3 _gridCellSize)
        {
            tilemap = _tilemap;
            checkRadius = IsometricGrid.GetObstacleCheckRadius();
        }

        public bool HasObstacle(Vector3 _pos, Vector3Int _gridPos, Sprite[] _obstacles)
        {
            Sprite _tile = tilemap.GetSprite(_gridPos);
            for (int _i = 0; _i < _obstacles.Length; _i++)
                if (_tile == _obstacles[_i])
                    return true;

            Collider2D[] _foundObstacles = Physics2D.OverlapCircleAll(_pos, checkRadius);
            if (_foundObstacles.Length == 0)
                return false;

            for (int _x = 0; _x < _foundObstacles.Length; _x++)
            {
                for (int _y = 0; _y < _obstacles.Length; _y++)
                {
                    if (!_foundObstacles[_x].TryGetComponent<SpriteRenderer>(out SpriteRenderer _spriteRenderer))
                        continue;
                    if (_spriteRenderer.sprite == _obstacles[_y])
                        return true;
                }
            }
            
            return false;
        }
    }
}