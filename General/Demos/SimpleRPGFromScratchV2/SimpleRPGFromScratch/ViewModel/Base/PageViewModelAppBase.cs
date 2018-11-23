using SimpleRPGFromScratch.Data.Base;
using SimpleRPGFromScratch.Model.App;
using SimpleRPGFromScratch.Model.Base;

namespace SimpleRPGFromScratch.ViewModel.Base
{
    /// <summary>
    /// Dette er den PageViewModel-klasse, som alle de klasse-specifikke PageViewModel-klasser
    /// i denne applikation skal arve fra. Her beslutter vi, at alle katalog-referencer skal
    /// sættes ved at kalde DomainModel.GetCatalog.
    /// </summary>
    /// <typeparam name="T">Typen af de domæne-objekter, som kataloget rummer.</typeparam>
    /// <typeparam name="TDVM">Typen for den tilsvarende Data View Model - klasse.</typeparam>
    public class PageViewModelAppBase<T, TDVM> : PageViewModelBase<T, TDVM> 
        where T : IDomainClass 
        where TDVM : class, IDataViewModel<T>, new()
    {
        protected override ICatalog<T> GetCatalog()
        {
            return DomainModel.GetCatalog<T>();
        }
    }
}