using UnityEngine;

namespace SimpleStrategy3D.Abstractions
{
    public abstract class CommandExecutorBase<T> : MonoBehaviour, ICommandExecutor
    {
        public void ExecuteCommand(object command) => ExecuteSpecificCommand((T) command);

        protected abstract void ExecuteSpecificCommand(T command);

    }
}