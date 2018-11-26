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

        protected override void Execute()
        {
            _catalog.Delete(_pageViewModel.ItemDetails.DataObject().GetId());
        }
    }
}