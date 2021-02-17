using UnityEngine;

namespace com.N8Dev.Brackeys.Sizing
{
    public class PlayerSizing : MonoBehaviour
    {
        //Player Sizes
        [SerializeField] private Transform[] PlayerSizes;
        [SerializeField] private Sizes CurrentSize;

        public Sizes GetSize() => CurrentSize;

        public Transform GetLowerSize() => PlayerSizes[Mathf.Min((int) CurrentSize + 1, PlayerSizes.Length)];

        public Transform GetBiggerSize() => PlayerSizes[Mathf.Max(0, (int) CurrentSize - 1)];
    }

    public enum Sizes
    {
        Large,
        Medium,
        Small
    }
}