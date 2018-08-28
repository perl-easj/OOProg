namespace SWCClasses.MVVM
{
    public class DeleteCommand<T> : CRUDCommandBase<T> 
        where T : DomainClassBase
    {
        public DeleteCommand(CatalogBase<T> catalog, PageViewModelBase<T> pageVM) 
            : base(catalog, pageVM)
        {
        }

        public override bool CanExecute()
        {
            return _pageVM.ItemSelected != null;
        }

        public override void Execute()
        {
            // Delete from catalog
            _catalog.Delete(_pageVM.ItemSelected.DomainObject.Key);

            // Set selection to null
            _pageVM.ItemSelected = null;

            // Refresh the item list
            _pageVM.RefreshDataViewModelCollection();

        }
    }
}