using UnityEngine;

namespace com.N8Dev.Brackeys.Sizing
{
    public interface ISlicer
    {
        public Vector3[] GetSliceKnockback();

        public Sizes GetSize();
    }
}