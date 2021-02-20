using System;
using com.N8Dev.Brackeys.GameData;
using com.N8Dev.Brackeys.Utilities;
using com.N8Dev.Brackeys.Inputs;
using com.N8Dev.Brackeys.InputSystem;
using UnityEngine;

namespace com.N8Dev.Brackeys.Movement
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