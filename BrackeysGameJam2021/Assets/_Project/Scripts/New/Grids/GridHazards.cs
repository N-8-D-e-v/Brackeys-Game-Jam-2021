using UnityEngine;

namespace com.N8Dev.Brackeys.GridMovement
{
    public class GridHazards
    {
        //Hazard Check
        private readonly float checkRadius;
        private readonly LayerMask hazardLayerMask;

        public GridHazards(Vector3 _gridCellSize)
        {
            checkRadius = Mathf.Min(_gridCellSize.x, _gridCellSize.y);
            hazardLayerMask = LayerMask.NameToLayer("Hazard");
        }

        public bool HasHazard(Vector3 _pos) => 
            Physics2D.OverlapCircle(_pos, checkRadius, hazardLayerMask);
    }
}