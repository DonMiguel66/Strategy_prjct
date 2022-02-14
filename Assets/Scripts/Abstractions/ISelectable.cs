using UnityEngine;

namespace Assets.Scripts.Abstractions
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