using UnityEngine;

namespace ScriptableObjects.Values
{
    [CreateAssetMenu(fileName = "BoolVariable", menuName = "Scriptable Objects/Bool Variable")]
    public class BoolVariable : ScriptableObject, IValue<bool>
    {
        public bool State => state;
        [ContextMenuItem("Reset", "ResetValue")]
        [SerializeField] private bool state;
        [TextArea]
        [SerializeField] private string description;

        private void Awake()
        {
            ResetValue();
        }

        public void SetState(bool state)
        {
            this.state = state;
        }

        public void ResetValue()
        {
            state = false;
        }
    }
}