using System.Windows.Input;
using BioDemo.ViewModels.Commands;
using BioDemo.ViewModels.Data;
using BioDemo.Views.Domain;
using ViewModel.App.Implementation;
using ViewModel.Flow.Implementation;

namespace BioDemo.ViewModels.Flow
{
    /// <summary>
    /// Flow view model for the last step in the "Buy Ticket" flow.
    /// In this step, the user selects a row and seat, based on the
    /// previously selected Show. The class also contains a command
    /// for creating the resulting Ticket object.
    /// </summary>
    public class BuyTicketFlowViewModelEnd : FlowViewModelEnd<TicketDataViewModel>
    {
        #region Instance fields
        private ICommand _createCommand;
        #endregion

        #region Constructor
        public BuyTicketFlowViewModelEnd()
            : base(AppViewModelBase.AppFrameInstance, typeof(BuyTicketViewA))
        {
            _createCommand = new CreateTicketCommand();
        }
        #endregion

        #region Properties for Data Binding
        public int Row
        {
            get { return FlowDataObject.Row; }
            set
            {
                FlowDataObject.Row = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(StatusText));
            }
        }

        public int Seat
        {
            get { return FlowDataObject.Seat; }
            set
            {
                FlowDataObject.Seat = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(StatusText));
            }
        }

        public string StatusText
        {
            get
            {
                return (FlowDataObject.ChosenShow == null ? "No Show selected..."
                    : $"Selected: {FlowDataObject.ChosenShow.MovieForShow.Title}" + "\n" +
                      $"In: {FlowDataObject.ChosenShow.TheaterForShow.Description}" + "\n" +
                      $"On: {FlowDataObject.ChosenShow.DateForShow.ToLongDateString()}" + "\n" +
                      $"At: {FlowDataObject.ChosenShow.TimeForShow.ToString()}" + "\n" +
                      $"Seating: Row {FlowDataObject.Row}, Seat {FlowDataObject.Seat}");
            }
        }

        public ICommand CreateCommand
        {
            get { return _createCommand; }
        } 
        #endregion
    }
}