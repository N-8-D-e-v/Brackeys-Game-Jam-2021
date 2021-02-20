using System;
using com.N8Dev.Allete.GameData;
using com.N8Dev.Allete.Inputs;
using com.N8Dev.Allete.InputSystem;
using com.N8Dev.Allete.Utilities;
using UnityEngine;

namespace com.N8Dev.Allete.Movement
{
    public class PlayerMovement : IsometricMovement
    {
        //Event
        public static event Action OnPlayerMove;
        
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
            CooldownTimer.OnCooledDown += () => OnPlayerMove?.Invoke();
        }

        private void OnEnable() => inputs?.Enable();

        private void OnDisable() => inputs?.Disable();

        private void Update()
        {
            if (!CooldownTimer.IsCooledDown())
                return;
            if (GameStateManager.GetGameState() != GameStates.Play)
                return;
            if (!inputs.IsPressingKey())
                return;
            
            CooldownTimer.StartCooldown();
            Move(inputs.GetInputDirection());
        }

        protected override IMovementView GetSuccessfulMovementView() => Jumping;

        protected override IMovementView GetUnsuccessfulMovementView() => Barrier; 
    }
}