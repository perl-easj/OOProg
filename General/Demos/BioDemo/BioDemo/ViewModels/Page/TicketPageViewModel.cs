using BioDemo.Data.Domain;
using BioDemo.Models.App;
using BioDemo.ViewModels.Base;
using BioDemo.ViewModels.Data;
using Data.InMemory.Interfaces;

namespace BioDemo.ViewModels.Page
{
    /// <summary>
    /// Page view model class for Ticket objects.
    /// Will be used as Data Context in the Ticket view.
    /// </summary>
    public class TicketPageViewModel : PageViewModelAppBase<Ticket>
    {
        #region Constructor
        public TicketPageViewModel() : base(DomainModel.Instance.TicketCatalog)
        {
        }
        #endregion

        #region Methods
        public override IDataWrapper<Ticket> CreateDataViewModel(Ticket obj)
        {
            return new TicketDataViewModel(obj);
        }
        #endregion
    }
}