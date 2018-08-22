using System;
using System.Threading.Tasks;
using Commands.Interfaces;

namespace Commands.Implementation
{
    public class RelayCommandAsync : INotifiableCommand
    {
        private readonly Func<Task> _execute;
        private readonly Func<bool> _canExecute;

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Use if command is always executable
        /// </summary>
        /// <param name="execute">
        /// Action to execute
        /// </param>
        public RelayCommandAsync(Func<Task> execute)
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
        public RelayCommandAsync(Func<Task> execute, Func<bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

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
        public async void Execute(object parameter)
        {
            await _execute();
        }

        /// <summary>
        /// Call this method if the object should re-evaluate
        /// if the command can be executed
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}