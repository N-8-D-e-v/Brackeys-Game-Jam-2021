using UnityEngine;

namespace com.N8Dev.Brackeys.GridMovement
{
    public class GridPositions
    {
        //Grid
        private readonly Grid grid;

        public GridPositions(Grid _grid) => grid = _grid;

        public Vector3 GetGridCellSize() => grid.cellSize;
        
        public Vector3 GetPosOnGrid(Vector3 _pos) => 
            GetWorldPosFromGridPos(GetGridPosFromWorldPos(_pos));

        public Vector3Int GetGridPosFromWorldPos(Vector3 _pos) => 
            grid.WorldToCell(_pos);

        private Vector3 GetWorldPosFromGridPos(Vector3Int _pos) => 
            new Vector3(grid.GetCellCenterWorld(_pos).x, grid.GetCellCenterWorld(_pos).y, 0f);
    }
}