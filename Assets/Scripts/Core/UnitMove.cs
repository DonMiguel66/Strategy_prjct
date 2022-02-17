using SimpleStrategy3D.Abstractions;
using UnityEngine;

namespace SimpleStrategy3D.Core
{
    public class UnitMove : CommandExecutorBase<IMoveCommand>
    {
        protected override void ExecuteSpecificCommand(IMoveCommand command)
        {
            Debug.Log("Move");
        }
    }
}