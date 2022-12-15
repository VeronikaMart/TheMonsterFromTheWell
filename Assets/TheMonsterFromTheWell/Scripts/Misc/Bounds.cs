using UnityEngine;

namespace TheMonsterFromTheWell.Misc
{
    public class Bounds : MonoBehaviour
    {
        [SerializeField] private float boundsOffset = 1f;
        private float minX, maxX;

        private void Start()
        {
            SetBoundaries();
        }

        private void Update()
        {
            if (transform.position.x < minX || transform.position.x > maxX)
            {
                ClampPosition();
            }
        }

        private void SetBoundaries()
        {
            Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

            maxX = bounds.x - boundsOffset;
            minX = -bounds.x + boundsOffset;
        }

        private void ClampPosition()
        {
            float rightPosition = Mathf.Clamp(transform.position.x, minX, maxX);

            Vector3 pos = transform.position;
            pos.x = rightPosition;
            transform.position = pos;
        }
    }
}