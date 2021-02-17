using UnityEngine;

namespace com.N8Dev.Brackeys.Sizing
{
    public interface ISizeable
    {
        public int GetID();
        
        public Sizes GetSize();

        public Transform GetLowerSize();

        public Transform GetBiggerSize();
    }
}