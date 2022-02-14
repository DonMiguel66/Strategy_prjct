using Assets.Scripts.Abstractions;
using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.SimpleStrategy3D
{
    public class MainBuilding : MonoBehaviour, IUnitProducer, ISelectable
    {
        [SerializeField]
        private GameObject _unitPrefab;
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
        public void ProduceUnit()
        {
            Instantiate(_unitPrefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity, _unitsParent);
        }

        public void Select()
        {
            _outline.OutlineMode = Outline.Mode.OutlineAll;
        }

        public void Deselect()
        {
            _outline.OutlineMode = Outline.Mode.None;
        }

    }
}