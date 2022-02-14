using System;
using UnityEngine;
using Assets.Scripts.Abstractions;

namespace Assets.Scripts.SimpleStrategy3D
{
    [CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "Strategy Game/"+ nameof(SelectableValue), order = 0)]
    public class SelectableValue : ScriptableObject
    {
        public ISelectable CurrentValue { get; private set; }
        public Action<ISelectable> OnSelected;

        public void SetValue(ISelectable value)
        {
            if (value == null && CurrentValue != null)
            {
                CurrentValue.Deselect();
            }
            CurrentValue = value;
            CurrentValue?.Select();
            OnSelected?.Invoke(value);
        }
    }
}
