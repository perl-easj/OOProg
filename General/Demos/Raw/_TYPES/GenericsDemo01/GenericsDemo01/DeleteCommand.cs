using System;
using System.Windows.Input;

namespace GenericsDemo01
{
    public class DeleteCommand<TKey, TViewModel> : ICommand
    {
        private IDelete<TKey> _deleteTarget;
        private TViewModel _viewModel;

        public DeleteCommand(IDelete<TKey> deleteTarget, TViewModel viewModel)
        {
            _deleteTarget = deleteTarget;
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _deleteTarget.Delete(_viewModel);
        }

        public event EventHandler CanExecuteChanged;
    }
}