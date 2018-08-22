using System.Windows.Input;

namespace Commands.Interfaces
{
    public interface ICommandBase : ICommand
    {
        void RaiseCanExecuteChanged();
    }
}