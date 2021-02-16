using UnityEngine;
using UnityEngine.Tilemaps;

namespace com.N8Dev.Brackeys.GridMovement
{
    public class GridTiles
    {
        //Tilemap
        private readonly Tilemap tilemap;

        public GridTiles(Tilemap _tilemap) => tilemap = _tilemap;

        public bool HasTile(Vector3Int _gridPos) => tilemap.HasTile(_gridPos);
    }
}