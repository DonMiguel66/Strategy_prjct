using UnityEngine;

namespace SimpleStrategy3D.Abstractions
{
    public interface IProduceUnitCommand : ICommand
    {
        GameObject UnitPrefab { get; }
    }
}

