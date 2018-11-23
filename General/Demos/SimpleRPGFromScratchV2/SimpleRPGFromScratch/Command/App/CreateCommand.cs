using SimpleRPGFromScratch.Data.Base;
using SimpleRPGFromScratch.Model.Base;
using SimpleRPGFromScratch.ViewModel.Base;

namespace SimpleRPGFromScratch.Command
{
    /// <summary>
    /// Specifik implementation af Create-logik.
    /// </summary>
    /// <typeparam name="T">Typen af domæne-objekter i Catalog-objektet</typeparam>
    /// <typeparam name="TDataViewModel">Typen af DVM-objekter i PVM-objektet</typeparam>
    public class CreateCommand<T, TDataViewModel> : CRUDCommandBase<T, TDataViewModel>
        where TDataViewModel : IDataViewModel<T>
        where T : IDomainClass
    {
        public CreateCommand(ICatalog<T> catalog, IPageViewModel<TDataViewModel> pageViewModel)
            : base(catalog, pageViewModel)
        {
        }

        /// <summary>
        /// NB: Denne metode er IKKE færdig
        /// </summary>
        protected override bool CanExecute()
        {
            return (_pageViewModel.ItemSelected != null) && (_pageViewModel.ItemSelected.DataObject() != null);
        }

        /// <summary>
        /// NB: Denne metode er IKKE færdig
        /// </summary>
        protected override void Execute()
        {
            _catalog.Create(_pageViewModel.ItemSelected.DataObject());
        }      
    }
}