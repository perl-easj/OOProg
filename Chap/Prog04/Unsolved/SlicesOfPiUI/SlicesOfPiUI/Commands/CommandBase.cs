using System;
using System.Windows.Input;

namespace SlicesOfPiUI.Commands
{
    /// <summary>
    /// Base class for commands. Adds RaiseCanExecuteChanged
    /// to standard command implementation.
    /// </summary>
    public abstract class CommandBase : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return CanExecute();
        }

        public void Execute(object parameter)
        {
            Execute();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(null, null);
        }

        public event EventHandler CanExecuteChanged;

        protected abstract bool CanExecute();
        protected abstract void Execute();       
    }
}