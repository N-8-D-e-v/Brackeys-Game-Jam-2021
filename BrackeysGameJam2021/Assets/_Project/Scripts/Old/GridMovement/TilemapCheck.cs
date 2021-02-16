using System;
using com.N8Dev.Brackeys.GridMovement;
using com.N8Dev.Brackeys.Old.GridMovement;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace com.N8Dev.Brackeys.Old.GridMovement
{
    [Serializable]
    public class TilemapCheck
    {
        //Tilemap Type
        [SerializeField] private TilemapTypes TilemapTypes;
        
        //Sprites
        [SerializeField] private Sprite[] Tiles;
        
        public bool HasTile(Vector3 _pos)
        {
            Tilemap _tilemap = TilemapReference.GetTilemap(TilemapTypes);
            Vector3Int _tilePosition = _tilemap.WorldToCell(_pos);

            if (!_tilemap.HasTile(_tilePosition))
                return false;

            Sprite _tileSprite = _tilemap.GetSprite(_tilePosition);
            for (int _i = 0; _i < Tiles.Length; _i++)
                if (Tiles[_i] == _tileSprite)
                    return true;

            return false;
        }
    }
}