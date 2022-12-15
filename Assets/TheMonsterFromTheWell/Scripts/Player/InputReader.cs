using DesignPatterns.Observer;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TheMonsterFromTheWell.Player
{
    public class InputReader : MonoBehaviour, PlayerControls.IPlayerActions
    {
        public Vector2 MovementValue { get; private set; }
        [SerializeField] private GameEvent JumpEvent;
        private PlayerControls controls;

        private void Start()
        {
            controls = new PlayerControls();
            // Reference to class, will call methods
            controls.Player.SetCallbacks(this);

            controls.Player.Enable();
        }

        private void OnDestroy()
        {
            controls.Player.Disable();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                JumpEvent.TriggerEvent();
            }
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            // If we press any move key, we store value 
            MovementValue = context.ReadValue<Vector2>();
        }
    }
}