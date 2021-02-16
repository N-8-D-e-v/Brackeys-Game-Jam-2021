using System;
using UnityEngine;

namespace com.N8Dev.Brackeys.GridMovement
{
    [Serializable]
    public class HazardCheck
    {
        //Layer
        [SerializeField] private LayerMask HazardLayerMask;
        
        //Sprites
        [SerializeField] private Sprite[] HazardSprites;
        
        //Radius
        private const float CHECK_RADIUS = 0.3f;

        public bool HasHazard(Vector3 _pos)
        {
            Collider2D _collider = Physics2D.OverlapCircle(_pos, CHECK_RADIUS, HazardLayerMask);
            if (!_collider)
                return false;
            if (!_collider.TryGetComponent<SpriteRenderer>(out SpriteRenderer _spriteRenderer))
                return false;
            for (int _i = 0; _i < HazardSprites.Length; _i++)
                if (_spriteRenderer.sprite == HazardSprites[_i])
                    return true;
            return false;
        }
    }
}