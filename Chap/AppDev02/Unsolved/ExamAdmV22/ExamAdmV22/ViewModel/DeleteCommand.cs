using System;
using System.Windows.Input;
using ExamAdmV22.Model;

namespace ExamAdmV22.ViewModel
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
            return _viewModel.SelectedStudent != null;
        }

        public void Execute(object parameter)
        {
            // Delete from catalog
            _catalog.Delete(_viewModel.SelectedStudent.DomainObject.Key);

            // Set selection to null
            _viewModel.SelectedStudent = null;

            // Refresh the item list
            _viewModel.RefreshStudentItemViewModelCollection();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;
    }
}