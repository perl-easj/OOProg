using System;
using System.Windows.Input;

namespace ExamAdmV23.DomainClasses
{
    public class DeleteCommand : ICommand
    {
        private StudentCatalog _catalog;
        private StudentPageViewModel _viewModel;

        public DeleteCommand(StudentCatalog catalog, StudentPageViewModel viewModel)
        {
            _catalog = catalog;
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return _viewModel.StudentSelected != null;
        }

        public void Execute(object parameter)
        {
            // Delete from catalog
            _catalog.Delete(_viewModel.StudentSelected.DomainObject.Key);

            // Set selection to null
            _viewModel.StudentSelected = null;

            // Refresh the item list
            _viewModel.RefreshStudentDataViewModelCollection();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;
    }
}