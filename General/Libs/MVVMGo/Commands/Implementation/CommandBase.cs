using System;
using Commands.Interfaces;

namespace Commands.Implementation
{
    /// <summary>
    /// Simple base class for commands invoked without
    /// parameters to Execute and CanExecute.
    /// </summary>
    public abstract class CommandBase : INotifiableCommand
    {
        public bool CanExecute(object parameter)
        {
            return CanExecute();
        }

        public void Execute(object parameter)
        {
            Execute();
        }

        protected virtual bool CanExecute()
        {
            return true;
        }

        protected abstract void Execute();

        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}