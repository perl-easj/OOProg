using System;
using System.Windows.Input;

namespace SWCClasses.MVVM
{
    public abstract class CommandBase : ICommand
    {
        #region Abstract methods
        public abstract bool CanExecute();
        public abstract void Execute();
        #endregion

        #region Methods
        public bool CanExecute(object parameter)
        {
            return CanExecute();
        }

        public void Execute(object parameter)
        {
            Execute();
        }
        #endregion

        #region RaiseCanExecuteChanged code
        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        } 
        #endregion
    }
}