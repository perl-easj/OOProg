using SimpleRPGFromScratch.Model.Base;
using SimpleRPGFromScratch.ViewModel.Base;

namespace SimpleRPGFromScratch.Command
{
    /// <summary>
    /// Basis-implementation af Command-klasse for CRUD-operationer.
    /// For disse operationer antages det, at vi altid har brug for:
    /// 1) En reference til et Catalog-objekt
    /// 2) En reference til et PageViewModel-objekt
    /// </summary>
    /// <typeparam name="T">Typen af domæne-objekter i Catalog-objektet</typeparam>
    /// <typeparam name="TDataViewModel">Typen af DVM-objekter i PVM-objektet</typeparam>
    public abstract class CRUDCommandBase<T, TDataViewModel> : CommandBase
    {
        protected ICatalog<T> _catalog;
        protected IPageViewModel<TDataViewModel> _pageViewModel;

        protected CRUDCommandBase(ICatalog<T> catalog, IPageViewModel<TDataViewModel> pageViewModel)
        {
            _catalog = catalog;
            _pageViewModel = pageViewModel;
        }
    }
}