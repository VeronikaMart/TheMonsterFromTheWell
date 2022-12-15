using DesignPatterns.Observer;
using ScriptableObjects.Values;
using UnityEngine;

namespace TheMonsterFromTheWell.Objects
{
    public class Treasure : MonoBehaviour
    {
        [SerializeField] private GameEvent TreasureCollected;
        [SerializeField] private BoolVariable collected;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            collected.SetState(true);
            TreasureCollected.TriggerEvent();
            Destroy(gameObject);
        }
    }
}