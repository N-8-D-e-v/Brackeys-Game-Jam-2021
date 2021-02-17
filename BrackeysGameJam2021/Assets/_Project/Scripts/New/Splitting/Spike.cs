using UnityEngine;

namespace com.N8Dev.Brackeys.Splitting
{
    public class Spike : MonoBehaviour, ISlicer
    {
        //Slice Knockback
        [SerializeField] private Vector3[] SliceKnockback = new Vector3[2];

        public Vector3[] GetSliceKnockback() => SliceKnockback;
    }
}