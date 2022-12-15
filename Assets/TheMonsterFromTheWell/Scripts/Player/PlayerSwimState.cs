using TheMonsterFromTheWell.Interface;
using TheMonsterFromTheWell.Player;
using UnityEngine;

public class PlayerSwimState : PlayerBaseState, IMovable
{
    private readonly int TriggerHash = Animator.StringToHash("Swim");

    public PlayerSwimState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter() { }

    public override void Exit() { }

    public override void Tick()
    {
        Move(stateMachine.InputReader.MovementValue.x);
        SetAnimation();
    }

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
        stateMachine.Animator.SetTrigger(TriggerHash);
    }
}