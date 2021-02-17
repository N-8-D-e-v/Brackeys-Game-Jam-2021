using UnityEngine;
using UnityEngine.Tilemaps;

namespace com.N8Dev.Brackeys.Grids
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Grid))]
    public class IsometricGrid : MonoBehaviour
    {
        //Assignables
        private static GridPositions gridPositions;
        private static GridTiles gridTiles;
        private static GridObstacles gridObstacles;
        
        //Offset
        [SerializeField] private Vector3 GridOffset = new Vector3(0f, 0.03f);
        private static Vector3 gridOffset;

        private void Awake()
        {
            gridPositions = new GridPositions(GetComponent<Grid>());
            gridTiles = new GridTiles(GetComponentInChildren<Tilemap>());
            gridObstacles = new GridObstacles(GetComponentInChildren<Tilemap>(), gridPositions.GetGridCellSize());
            gridOffset = GridOffset;
        }

        private void Update() => gridOffset = GridOffset;
        
        public static float GetObstacleCheckRadius() => 
            Mathf.Min(gridPositions.GetGridCellSize().x, gridPositions.GetGridCellSize().y) / 3;

        public static Vector3 VectorToDirection(Vector3 _dirVector)
        {
            if (_dirVector == Vector3.left)
                return Left();
            else if (_dirVector == Vector3.right)
                return Right();
            else if (_dirVector == Vector3.up)
                return Up();
            else if (_dirVector == Vector3.down)
                return Down();
            else
                return Vector3.zero;
        }

        public static Vector3 GetPosOnGrid(Vector3 _pos) => 
            gridPositions.GetPosOnGrid(_pos) + gridOffset;

        public static bool HasTile(Vector3 _pos) => 
            gridTiles.HasTile(gridPositions.GetGridPosFromWorldPos(_pos));

        public static bool HasObstacle(Vector3 _pos, Sprite[] _obstacles) => 
            gridObstacles.HasObstacle(_pos, gridPositions.GetGridPosFromWorldPos(_pos), _obstacles);

        private static Vector3 Left() => 
            new Vector3(-gridPositions.GetGridCellSize().x, gridPositions.GetGridCellSize().y, 0f) / 2;

        private static Vector3 Right() => 
            new Vector3(gridPositions.GetGridCellSize().x, -gridPositions.GetGridCellSize().y, 0f) / 2;

        private static Vector3 Up() => 
            new Vector3(gridPositions.GetGridCellSize().x, gridPositions.GetGridCellSize().y, 0f) / 2;

        private static Vector3 Down() => 
            new Vector3(-gridPositions.GetGridCellSize().x, -gridPositions.GetGridCellSize().y, 0f) / 2;
    }
}