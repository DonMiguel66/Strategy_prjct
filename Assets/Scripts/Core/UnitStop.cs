using SimpleStrategy3D.Abstractions;
using UnityEngine;

namespace SimpleStrategy3D.Core
{
    public class UnitStop : CommandExecutorBase<IStopCommand>
    {
        protected override void ExecuteSpecificCommand(IStopCommand command)
        {
            Debug.Log("STOP");
        }
    }
}