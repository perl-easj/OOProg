using System.Windows.Input;

namespace Commands.Interfaces
{
    /// <summary>
    /// Extends the ICommand interface with the standard
    /// RaiseCanExecuteChanged method, enabling commands
    /// to re-evaluate the CanExecute predicate on request.
    /// </summary>
    public interface INotifiableCommand : ICommand
    {
        void RaiseCanExecuteChanged();
    }
}