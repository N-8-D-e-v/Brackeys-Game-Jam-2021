using UnityEngine;
using UnityEngine.Tilemaps;

namespace com.N8Dev.Brackeys.GridMovement
{
    [RequireComponent(typeof(Tilemap))]
    public class TilemapReference : MonoBehaviour
    {
        //Tilemaps
        private static readonly Tilemap[] TILEMAPS = new Tilemap[1];
        
        //Tilemap Type
        [SerializeField] private TilemapTypes TilemapType;

        private void Awake() => TILEMAPS[(int) TilemapType] = GetComponent<Tilemap>();
        
        public static Tilemap GetTilemap(TilemapTypes _tilemapTypes) => TILEMAPS[(int) _tilemapTypes];
    }

    public enum TilemapTypes
    {
        Ground
    }
}