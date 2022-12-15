using TheMonsterFromTheWell.Interface;
using UnityEngine;

namespace TheMonsterFromTheWell.Player
{
    public class PlayerMoveState : PlayerBaseState, IMovable
    {
        private readonly int SpeedHash = Animator.StringToHash("Speed");
        public PlayerMoveState(PlayerStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter() 
        {
            stateMachine.Animator.SetTrigger("Walk");
        }

        public override void Tick()
        {
            Move(stateMachine.InputReader.MovementValue.x);
            SetAnimation();
        }

        public override void Exit() { }

        public void Move(float direction)
        {
            if (ReferenceEquals(direction, null))
                return;

            stateMachine.PlayerRigidbody.velocity = new Vector2(stateMachine.MovementSpeedCurve.Evaluate(direction),
                    stateMachine.PlayerRigidbody.velocity.y);

            LookAt(direction);
        }

        public bool LookAt(float direction)
        {
            if (direction == 0f)
                return false;

            return stateMachine.SpriteRenderer.flipX = direction <= 0;
        }

        public void SetAnimation()
        {
            if (stateMachine.InputReader.MovementValue == Vector2.zero)
            {
                stateMachine.Animator.SetFloat(SpeedHash, 0);
                return;
            }

            stateMachine.Animator.SetFloat(SpeedHash, 1);
        }
    }
}