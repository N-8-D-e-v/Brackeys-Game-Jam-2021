using UnityEngine;

namespace com.N8Dev.Brackeys.GridMovement
{
    [RequireComponent(typeof(Freezing), typeof(GridPositioning))]
    public class KnockbackController : MonoBehaviour
    {
        //Assignables
        private new Transform transform;
        private Freezing freezing;
        private GridPositioning gridPositioning;
        
        //Knockback
        [SerializeField] private Knockback Knockback;

        private void Awake()
        {
            transform = GetComponent<Transform>();
            freezing = GetComponent<Freezing>();
            gridPositioning = GetComponent<GridPositioning>();
        }

        public void Knock(Vector2 _direction) => 
            Knockback.Knock
                (transform, gridPositioning.GetNextPosition(transform.position, _direction), freezing);
    }
}