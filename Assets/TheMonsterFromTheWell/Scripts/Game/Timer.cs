using TheMonsterFromTheWell.Interface;
using TMPro;
using UnityEngine;

namespace TheMonsterFromTheWell.Game
{
    public class Timer : MonoBehaviour, IDisplay
    {
        [SerializeField] private TextMeshProUGUI timeText;
        private float time;
        private bool gameStarted;

        private void Start()
        {
            SetState(true);
        }

        private void Update()
        {
            StartTimer();
            Display(timeText);
        }

        public void SetState(bool state)
        {
            gameStarted = state;
        }

        public void Display(TextMeshProUGUI text)
        {
            text.text = $"Time: {time}";
        }

        private void StartTimer()
        {
            if (!gameStarted)
                return;

            time += Time.deltaTime;
        }
    }
}