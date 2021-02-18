using UnityEngine;

namespace com.N8Dev.Brackeys.GameState
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class WinningTrigger : MonoBehaviour
    {
        //Winning
        [SerializeField] private Winning Winning;

        private void OnTriggerEnter2D(Collider2D _collider) => 
            Winning.CheckWin(_collider.gameObject);
    }
}