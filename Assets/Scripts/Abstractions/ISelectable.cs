using UnityEngine;

namespace SimpleStrategy3D.Abstractions
{
    public interface ISelectable
    {
        float Health { get; }
        float MaxHealth { get; }
        RenderTexture Icon { get; }
        void Select();
        void Deselect();
    }
}