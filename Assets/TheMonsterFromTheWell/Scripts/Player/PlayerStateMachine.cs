using TheMonsterFromTheWell.StateMachines;
using UnityEngine;

namespace TheMonsterFromTheWell.Player
{
    public class PlayerStateMachine : StateMachine
    {
        [field: SerializeField] public InputReader InputReader { get; private set; }
        [field: SerializeField] public SpriteRenderer SpriteRenderer { get; private set; }
        [field: SerializeField] public Rigidbody2D PlayerRigidbody { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }
        [Space]
        [Tooltip("The (time) value determines the direction of movement (- 1 Left, 1 Right). The (value) determines the speed parameter.")]
        [field: SerializeField] public AnimationCurve MovementSpeedCurve;
        [field: SerializeField] public int JumpForce { get; private set; }
        [Space]
        [SerializeField] private LayerMask groundMask;
        [SerializeField] private float rayDistance = .1f;
        private const int WaterLayer = 4;

        private void Start()
        {
            SwitchState(new PlayerMoveState(this));
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == WaterLayer)
            {
                SwitchState(new PlayerSwimState(this));
            }
        }
        
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.layer == WaterLayer)
            {
                SwitchState(new PlayerMoveState(this));
            }
        }

        public void PerformJump()
        {
            if (IsLanded())
            {
                SwitchState(new PlayerJumpState(this));
                SwitchState(new PlayerMoveState(this));
            }
        }

        private bool IsLanded()
        {
            return Physics2D.BoxCast(transform.position, Vector2.one, 0f, Vector2.down, rayDistance, groundMask)
                ? true : false;
        }
    }
}