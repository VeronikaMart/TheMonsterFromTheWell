using DesignPatterns.Observer;
using UnityEngine;

namespace TheMonsterFromTheWell.Enemy
{
    public class TrapTrigger : MonoBehaviour
    {
        [SerializeField] private GameEvent StepOnTrap;
        private bool stepOnTrap = false;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (stepOnTrap)
                return;
            
            StepOnTrap.TriggerEvent();
            stepOnTrap = true;
        }
    }
}