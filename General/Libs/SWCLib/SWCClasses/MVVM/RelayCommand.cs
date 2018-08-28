using System;

namespace SWCClasses.MVVM
{
    /// <summary>
    /// This class is the "standard" implementation of RelayCommand,
    /// which originates from an open-source MVVM project (MVVMLight).
    /// It has been extended with the RaiseCanExecuteChanged method.
    /// </summary>
    public class RelayCommand
    {
        #region Instance fields
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;
        #endregion

        #region Constructors
        /// <summary>
        /// Use if command is always executable
        /// </summary>
        /// <param name="execute">
        /// Action to execute
        /// </param>
        public RelayCommand(Action execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Use if command may not always be executable
        /// </summary>
        /// <param name="execute">
        /// Action to execute
        /// </param>
        /// <param name="canExecute">
        /// Function should return true when command is executable
        /// </param>
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Returns true if command is executable
        /// </summary>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        /// <summary>
        /// Execute the command specified when object was created
        /// </summary>
        public void Execute(object parameter)
        {
            _execute();
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