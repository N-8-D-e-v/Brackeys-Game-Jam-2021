using com.N8Dev.Brackeys.Inputs;
using com.N8Dev.Brackeys.InputSystem;
using UnityEngine;

namespace com.N8Dev.Brackeys.Movement
{
    public class PlayerMovement : IsometricMovement
    {
        //Movement
        private PlayerInputs inputs;

        //Movement Views
        [Header("Movement Views")]
        [SerializeField] private Jumping Jumping;
        [SerializeField] private Barrier Barrier;
        
        //Cooldown
        [Header("Cooldown")]
        [SerializeField] private CooldownTimer CooldownTimer;

        protected override void Awake()
        {
            base.Awake();
            inputs = new PlayerInputs(new Inputs_Player());
        }

        private void OnEnable() => inputs.Enable();

        private void OnDisable() => inputs.Disable();

        private void Update()
        {
            if (!CooldownTimer.IsCooledDown())
                return;
            if (inputs.IsPressingKey())
                CooldownTimer.StartCooldown();
            Move(inputs.GetInputDirection());
        }

        protected override IMovementView GetSuccessfulMovementView() => Jumping;

        protected override IMovementView GetUnsuccessfulMovementView() => Barrier; 
    }
}