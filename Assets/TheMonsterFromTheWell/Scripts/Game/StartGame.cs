using ScriptableObjects.Values;
using UnityEngine;

namespace TheMonsterFromTheWell.Game
{
    public class StartGame : MonoBehaviour
    {
        [SerializeField] private BoolVariable collected;

        private void Start()
        {
            collected.SetState(false);
        }
    }
}