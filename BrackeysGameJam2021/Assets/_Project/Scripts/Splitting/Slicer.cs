using System.Collections.Generic;
using UnityEngine;

namespace com.N8Dev.Brackeys.Splitting
{
    public class Slicer : MonoBehaviour
    {
        //Knockback Directions
        [SerializeField] private Vector3[] KnockbackDirections;

        public IEnumerable<Vector3> GetKnockbackDirections() => KnockbackDirections;
    }
}