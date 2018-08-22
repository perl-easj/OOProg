using BioDemo.Models.App;
using BioDemo.ViewModels.Data;
using BioDemo.Views.Domain;
using Commands.Implementation;
using ViewModel.App.Implementation;
using ViewModel.Flow.Implementation;

namespace BioDemo.ViewModels.Commands
{
    /// <summary>
    /// Class for handling Ticket creation. Actually, the Ticket object
    /// has already been created through a "flow" process, so the command
    /// just inserts the object into the TicketCatalog. After this, the
    /// Ticket flow is reset
    /// </summary>
    public class CreateTicketCommand : CommandBase
    {
        protected override void Execute()
        {
            DomainModel.Instance.TicketCatalog.Create(FlowViewModelBase<TicketDataViewModel>.FlowDataObject.DataObject);
            FlowViewModelBase<TicketDataViewModel>.ResetFlowDataObject();
            AppViewModelBase.AppFrameInstance.Navigate(typeof(BuyTicketViewStart));
        }
    }
}