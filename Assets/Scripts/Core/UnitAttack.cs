using SimpleStrategy3D.Abstractions;
using UnityEngine;

namespace SimpleStrategy3D.Core
{
    public class UnitAttack : CommandExecutorBase<IAttackCommand>
    {
        protected override void ExecuteSpecificCommand(IAttackCommand command)
        {
            Debug.Log("Attacks");
        }
    }
}
