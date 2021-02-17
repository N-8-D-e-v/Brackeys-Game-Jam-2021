using UnityEngine;

namespace com.N8Dev.Brackeys.Sizing
{
    public class Spike : MonoBehaviour, ISlicer
    {
        //Size
        [SerializeField] private Sizes Size;
        
        //Slice Knockback
        [SerializeField] private Vector3[] SliceKnockback = new Vector3[2];

        public Vector3[] GetSliceKnockback() => SliceKnockback;

        public Sizes GetSize() => Size;
    }
}