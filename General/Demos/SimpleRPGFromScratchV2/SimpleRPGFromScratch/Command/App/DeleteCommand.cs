using SimpleRPGFromScratch.Data.Base;
using SimpleRPGFromScratch.Model.Base;
using SimpleRPGFromScratch.ViewModel.Base;

namespace SimpleRPGFromScratch.Command
{
    /// <summary>
    /// Specifik implementation af Delete-logik.
    /// </summary>
    /// <typeparam name="T">Typen af domæne-objekter i Catalog-objektet</typeparam>
    /// <typeparam name="TDataViewModel">Typen af DVM-objekter i PVM-objektet</typeparam>
    public class DeleteCommand<T, TDataViewModel> : CRUDCommandBase<T, TDataViewModel>
        where TDataViewModel : IDataViewModel<T>
        where T :IDomainClass
    {
        public DeleteCommand(ICatalog<T> catalog, IPageViewModel<TDataViewModel> pageViewModel) 
            : base(catalog, pageViewModel)
        {
        }

        /// <summary>
        /// Delete kan kun udføres, når der er valgt et element i PVM
        /// </summary>
        protected override bool CanExecute()
        {
            return (_pageViewModel.ItemSelected != null) && (_pageViewModel.ItemSelected.DataObject() != null);
        }

        /// <summary>
        /// Delete udføres ved at slette det i PVM valgte element fra Catalog-objektet.
        /// </summary>
        protected override void Execute()
        {
            _catalog.Delete(_pageViewModel.ItemSelected.DataObject().GetId());
        }
    }
}