using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace com.N8Dev.Brackeys.GridMovement
{
    [Serializable]
    public class TilemapCheck
    {
        //Assignables
        private Tilemap tilemap;
        
        //Tilemap Type
        [SerializeField] private TilemapTypes TilemapType;

        public bool HasTile(Vector3 _pos)
        {
            if (!tilemap)
                tilemap = TilemapReference.GetTilemap(TilemapType);
            return tilemap.HasTile(tilemap.WorldToCell(_pos));
        }
    }
}