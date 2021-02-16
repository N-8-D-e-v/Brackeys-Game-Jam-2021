using System;
using UnityEngine;

namespace com.N8Dev.Brackeys.Splitting
{
    [Serializable]
    public class CharacterSizes
    {
        //Sizes
        [SerializeField] private SpriteRenderer[] Sizes;
        [SerializeField] private int CurrentSize;

        public SpriteRenderer GetSmallerSize()
        {
            if (CurrentSize + 1 >= Sizes.Length)
                return null;
            CurrentSize += 1;
            return Sizes[CurrentSize];
        }

        public SpriteRenderer GetBiggerSize()
        {
            if (CurrentSize - 1 < 0)
                return null;
            CurrentSize -= 1;
            return Sizes[CurrentSize];
        }
    }
}