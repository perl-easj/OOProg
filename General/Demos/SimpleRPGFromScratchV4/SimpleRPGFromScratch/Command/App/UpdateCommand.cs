using SimpleRPGFromScratch.Command.Base;
using SimpleRPGFromScratch.Data.Base;
using SimpleRPGFromScratch.Model.Base;
using SimpleRPGFromScratch.ViewModel.Base;

namespace SimpleRPGFromScratch.Command.App
{
    /// <summary>
    /// Specifik implementation af Update-logik.
    /// </summary>
    /// <typeparam name="T">Typen af domæne-objekter i Catalog-objektet</typeparam>
    /// <typeparam name="TDataViewModel">Typen af DVM-objekter i PVM-objektet</typeparam>
    public class UpdateCommand<T, TDataViewModel> : CRUDCommandBase<T, TDataViewModel>
        where TDataViewModel : IDataViewModel<T>
        where T : IDomainClass
    {
        public UpdateCommand(ICatalog<T> catalog, IPageViewModel<TDataViewModel> pageViewModel) 
            : base(catalog, pageViewModel)
        {
        }

        protected override void Execute()
        {
            T obj = _pageViewModel.ItemDetails.DataObject();
            _catalog.Update(obj.GetId(), obj);
        }
    }
}