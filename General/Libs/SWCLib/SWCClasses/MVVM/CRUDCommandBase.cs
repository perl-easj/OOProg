namespace SWCClasses.MVVM
{
    public abstract class CRUDCommandBase<T> : CommandBase 
        where T : class
    {
        protected CatalogBase<T> _catalog;
        protected PageViewModelBase<T> _pageVM;

        protected CRUDCommandBase(CatalogBase<T> catalog, PageViewModelBase<T> pageVM)
        {
            _catalog = catalog;
            _pageVM = pageVM;
        }
    }
}