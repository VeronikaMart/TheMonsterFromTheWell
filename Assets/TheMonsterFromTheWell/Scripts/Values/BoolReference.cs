using System;
using UnityEngine;

namespace ScriptableObjects.Values
{
    [Serializable]
    public class BoolReference
    {
        [SerializeField] private BoolVariable state;
        public bool State => state.State;

        public static implicit operator bool(BoolReference reference) => reference.State;
    }
}