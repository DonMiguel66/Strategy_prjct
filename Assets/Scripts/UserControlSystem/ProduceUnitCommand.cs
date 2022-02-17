using SimpleStrategy3D.Abstractions;
using SimpleStrategy3D.Utils;
using UnityEngine;

namespace SimpleStrategy3D.UserControlSystem
{
    public class ProduceUnitCommand : IProduceUnitCommand
    {
        public GameObject UnitPrefab => _unitPrefab;
        [InjectAsset("Chomper")]private GameObject _unitPrefab;
    }
}
