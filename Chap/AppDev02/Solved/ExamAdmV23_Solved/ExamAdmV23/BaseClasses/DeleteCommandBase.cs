using System;
using System.Windows.Input;

namespace ExamAdmV23.BaseClasses
{
    public class DeleteCommandBase<TDomainClass, TViewModel> : ICommand
        where TViewModel : PageViewModelBase<TDomainClass>
        where TDomainClass : DomainClassBase
    {
        private CatalogBase<TDomainClass> _catalog;
        private TViewModel _viewModel;

        public DeleteCommandBase(CatalogBase<TDomainClass> catalog, TViewModel viewModel)
        {
            _catalog = catalog;
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return _viewModel.ItemSelected != null;
        }

        public void Execute(object parameter)
        {
            // Delete from catalog
            _catalog.Delete(_viewModel.ItemSelected.DomainObject.Key);

            // Set selection to null
            _viewModel.ItemSelected = null;

            // Refresh the item list
            _viewModel.RefreshDataViewModelCollection();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;
    }
}