using SimpleStrategy3D.Abstractions;
using UnityEngine;

namespace SimpleStrategy3D.Core
{
    public class MainBuilding : CommandExecutorBase<IProduceUnitCommand>, ISelectable
    {
        [SerializeField]
        private Transform _unitsParent;
        [SerializeField]
        private float _maxHealth;
        [SerializeField] 
        private RenderTexture _icon;
        [SerializeField] 
        private Outline _outline;

        private float _health = 1000;
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public RenderTexture Icon => _icon;
        
        public void Select()
        {
            _outline.OutlineMode = Outline.Mode.OutlineAll;
        }

        public void Deselect()
        {
            _outline.OutlineMode = Outline.Mode.None;
        }
        protected override void ExecuteSpecificCommand(IProduceUnitCommand command)
        {
            Instantiate(command.UnitPrefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity, _unitsParent);
        }

    }
}