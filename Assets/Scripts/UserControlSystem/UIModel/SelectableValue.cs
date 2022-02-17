using System;
using UnityEngine;
using SimpleStrategy3D.Abstractions;

namespace SimpleStrategy3D.UIModels
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
