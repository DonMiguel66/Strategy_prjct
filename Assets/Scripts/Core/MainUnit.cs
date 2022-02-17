using SimpleStrategy3D.Abstractions;
using UnityEngine;

namespace SimpleStrategy3D.Core
{
    public class MainUnit : MonoBehaviour, ISelectable
    {
        [SerializeField] private float _maxHealth = 1000f;
        [SerializeField] private RenderTexture _icon;
        [SerializeField] private Outline _outline;
        private float _health;

        public float Health => _health;

        public float MaxHealth => _maxHealth;

        public RenderTexture Icon => _icon;

        private void Awake()
        {
            _health = _maxHealth;
        }

        public void Deselect()
        {
            _outline.OutlineMode = Outline.Mode.None;
        }

        public void Select()
        {
            _outline.OutlineMode = Outline.Mode.OutlineAll;
        }
    }
}
