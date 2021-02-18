using UnityEngine;

namespace com.N8Dev.Brackeys.Winning
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(BoxCollider2D))]
    public class WinningTrigger : MonoBehaviour
    {
        //Winning
        [SerializeField] private Win Win;

        private void OnTriggerEnter2D(Collider2D _collider) => 
            Win.CheckWin(_collider.gameObject);
    }
}