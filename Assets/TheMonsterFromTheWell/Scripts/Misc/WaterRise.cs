using ScriptableObjects.Values;
using UnityEngine;

namespace TheMonsterFromTheWell.Misc
{
    public class WaterRise : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private float maxWaterLevel = 59f;
        [SerializeField] BoolReference treasureCollected;
        [SerializeField] private AudioSource waterSound;
        private bool stopRise;
        

        private void Update()
        {
            if (transform.position.y >= maxWaterLevel || stopRise)
            {
                waterSound.Stop();
                return;
            }

            if (treasureCollected.State)
                Rise();
        }

        private void Rise()
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

        public void StopRise()
        {
            stopRise = true;
        }
    }
}