using DesignPatterns.Observer;
using UnityEngine;

namespace TheMonsterFromTheWell.Misc
{
    public class DeadZone : MonoBehaviour
    {
        [SerializeField] private GameEvent GameOverEvent;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            GameOverEvent.TriggerEvent();
            Destroy(collision.gameObject);
        }
    }
}