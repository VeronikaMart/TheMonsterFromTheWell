using UnityEngine;

namespace TheMonsterFromTheWell.Player
{
    public class PlayerJumpState : PlayerBaseState
    {
        public PlayerJumpState(PlayerStateMachine stateMachine) : base(stateMachine) { }
        public override void Enter()
        {
            Jump();
        }

        public override void Tick() { }

        public override void Exit() { }

        private void Jump()
        {
            stateMachine.PlayerRigidbody.AddForce(Vector2.up * stateMachine.JumpForce, ForceMode2D.Impulse);
        }
    }
}