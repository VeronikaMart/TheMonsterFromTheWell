using DesignPatterns.Observer;
using ScriptableObjects.Values;
using UnityEngine;

namespace TheMonsterFromTheWell.Game
{
    public class VictoryTrigger : MonoBehaviour
    {
        [SerializeField] private GameEvent VctoryEvent;
        [SerializeField] private BoolReference collected;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collected.State)
                return;

            VctoryEvent.TriggerEvent();
        }
    }
}