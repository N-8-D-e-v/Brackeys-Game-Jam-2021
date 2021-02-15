using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace com.N8Dev.Brackeys.GridMovement
{
    [Serializable]
    public class TilemapCheck
    {
        //Assignables
        [SerializeField] private Tilemap Tilemap;

        public bool HasTile(Vector3 _pos) => Tilemap.HasTile(Tilemap.WorldToCell(_pos));
    }
}