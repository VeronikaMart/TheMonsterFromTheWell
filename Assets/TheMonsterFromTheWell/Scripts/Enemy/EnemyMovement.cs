using TheMonsterFromTheWell.Interface;
using UnityEngine;

namespace TheMonsterFromTheWell.Enemy
{
    public class EnemyMovement : MonoBehaviour, IMovable
    {
        [SerializeField] private float speed = 10;
        private float direction;
        private bool isVisible = true;

        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            GetDirection();
            LookAt(direction);
        }

        private void Update()
        {
            if (!isVisible)
                return;

            Move(direction);
        }

        private void OnBecameInvisible()
        {
            isVisible = false;
            gameObject.SetActive(false);
        }

        public bool LookAt(float direction)
        {
            return spriteRenderer.flipX = direction <= 0;
        }

        public void Move(float direction)
        {
            transform.Translate(new Vector2(direction, 0) * speed * Time.deltaTime);
        }

        private float GetDirection()
        {
            return direction = (float)(transform.position.x > 0 ? Direction.LEFT : Direction.RIGHT);
        }

        public void SetAnimation()
        {
            // Move animation
        }
    }
}