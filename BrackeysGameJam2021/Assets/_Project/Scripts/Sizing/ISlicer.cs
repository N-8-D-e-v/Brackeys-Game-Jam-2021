using UnityEngine;

namespace com.N8Dev.Allete.Sizing
{
    public interface ISlicer
    {
        public Vector3[] GetSliceKnockback();

        public Sizes GetSize();
    }
}