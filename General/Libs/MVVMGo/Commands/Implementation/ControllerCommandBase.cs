using System;
using Commands.Interfaces;
using Controllers.Interfaces;

namespace Commands.Implementation
{
    /// <inheritdoc />
    /// <summary>
    /// Base class for any command which operates by
    /// calling Run on a simple controller.
    /// </summary>
    public abstract class ControllerCommandBase : CommandBase
    {
        protected ISimpleController Controller;
        protected Func<bool> Condition;

        protected ControllerCommandBase(ISimpleController controller, Func<bool> condition)
        {
            Controller = controller;
            Condition = condition;
        }

        /// <summary>
        /// Invoke the controller corresponding to the command.
        /// </summary>
        protected override void Execute()
        {
            Controller.Run();
        }

        /// <summary>
        /// Evaluate if command can be executed.
        /// </summary>
        protected override bool CanExecute()
        {
            return Condition();
        }
    }
}