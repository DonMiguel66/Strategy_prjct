using System;
using System.Collections.Generic;
using SimpleStrategy3D.Abstractions;
using SimpleStrategy3D.UIModels;
using SimpleStrategy3D.UIView;
using SimpleStrategy3D.UserControlSystem;
using SimpleStrategy3D.Utils;
using UnityEngine;

namespace SimpleStrategy3D.UIPresenters
{
    public class CommandButtonsPresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectable;
        [SerializeField] private CommandButtonsView _view;
        [SerializeField] private AssetsContext _context;

        private ISelectable _currentSelectable;

        private void Start()
        {
            _selectable.OnSelected += onSelected;
            onSelected(_selectable.CurrentValue);
            _view.OnClick += OnButtonClick;
        }

        private void onSelected(ISelectable selectable)
        {
            if (_currentSelectable == selectable)
            {
                return;
            }

            _currentSelectable = selectable;
            _view.Clear();

            if (selectable != null)
            {
                var commandExecutors = new List<ICommandExecutor>();
                commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
                _view.MakeLayout(commandExecutors);
            }
        }

        private void OnButtonClick(ICommandExecutor commandExecutor)
        {
            switch (commandExecutor)
            {
                case CommandExecutorBase<IProduceUnitCommand> unitProducer:
                    unitProducer.ExecuteCommand(_context.Inject(new ProduceUnitCommandHeir()));
                    break;
                case CommandExecutorBase<IAttackCommand> unitAttack:
                    unitAttack.ExecuteCommand(new AttackCommand()); // TODO: возможо будет необходимо внедрение зависимоти.
                    break;
                case CommandExecutorBase<IMoveCommand> unitMove:
                    unitMove.ExecuteCommand(new MoveUnitCommand()); // TODO: возможо будет необходимо внедрение зависимоти.
                    break;
                case CommandExecutorBase<IPatrolCommand> unitPatrol:
                    unitPatrol.ExecuteCommand(new PatrolCommand()); // TODO: возможо будет необходимо внедрение зависимоти.
                    break;
                case CommandExecutorBase<IStopCommand> unitStop:
                    unitStop.ExecuteCommand(new StopCommand()); // TODO: возможо будет необходимо внедрение зависимоти.
                    break;
                default:
                    throw new ApplicationException($"{nameof(CommandButtonsPresenter)}.{nameof(OnButtonClick)}: Unknown type of commands executor: {commandExecutor.GetType().FullName}!");
            }
        }
    }

}

