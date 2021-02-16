using com.N8Dev.Brackeys.Inputs;
using com.N8Dev.Brackeys.InputSystem;
using UnityEngine;

namespace com.N8Dev.Brackeys.Movement
{
    [RequireComponent(typeof(IFreezable))]
    public class PlayerMovement : IsometricMovement
    {
        //Assignables
        private IFreezable freezable;
        private PlayerInputs inputs;
        
        //Stats
        [SerializeField] private Jumping Jumping;

        protected override void Awake()
        {
            base.Awake();
            freezable = GetComponent<IFreezable>();
            inputs = new PlayerInputs(new Inputs_Player());
        }

        private void OnEnable() => inputs.Enable();

        private void OnDisable() => inputs.Disable();

        private void Update()
        {
            if (freezable.IsFrozen())
                return;
            Move(inputs.GetInputDirection());
        }

        protected override IMovementView GetSuccessfulMovementView() => Jumping;

        protected override IMovementView GetUnsuccessfulMovementView() => null; //TODO make this 
    }
}