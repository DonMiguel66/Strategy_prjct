using SimpleStrategy3D.Abstractions;
using UnityEngine;

namespace SimpleStrategy3D.Core
{
    public class UnitPartol : CommandExecutorBase<IPatrolCommand>
    {
        protected override void ExecuteSpecificCommand(IPatrolCommand command)
        {
            Debug.Log("Patrol");
        }
    }
}