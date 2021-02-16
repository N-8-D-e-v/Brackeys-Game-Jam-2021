using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace com.N8Dev.Brackeys.GridMovement
{
    [RequireComponent(typeof(Tilemap))]
    public class TilemapReference : MonoBehaviour
    {
        //Assignables
        private static Tilemap groundTilemap;
        
        //TilemapType
        [SerializeField] private TilemapTypes TilemapType;
        
        //Dictionary
        private static readonly Dictionary<TilemapTypes, Tilemap> TILEMAPS = new Dictionary<TilemapTypes, Tilemap>()
        {
            { TilemapTypes.Ground, groundTilemap }
        };

        private void Awake() => TILEMAPS[TilemapType] = GetComponent<Tilemap>();

        public static Tilemap GetTilemap(TilemapTypes _tilemapType) => TILEMAPS[_tilemapType];
    }

    public enum TilemapTypes
    {
        Ground
    }
}