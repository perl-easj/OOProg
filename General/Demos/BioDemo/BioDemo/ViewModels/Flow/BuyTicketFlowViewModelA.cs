using System.Collections.Generic;
using System.Linq;
using BioDemo.Data.Domain;
using BioDemo.ViewModels.Data;
using BioDemo.ViewModels.Page;
using BioDemo.Views.Domain;
using Data.InMemory.Interfaces;
using ViewModel.App.Implementation;
using ViewModel.Flow.Implementation;

namespace BioDemo.ViewModels.Flow
{
    /// <summary>
    /// Flow view model for the second step in the "Buy Ticket" flow.
    /// In this step, the user selects a Show, based on the previously
    /// selected Movie.
    /// </summary>
    public class BuyTicketFlowViewModelA : FlowViewModelBase<TicketDataViewModel>
    {
        #region Instance fields
        private ShowPageViewModel _showPVM;
        #endregion

        #region Constructor
        public BuyTicketFlowViewModelA()
            : base(AppViewModelBase.AppFrameInstance, typeof(BuyTicketViewStart), typeof(BuyTicketViewEnd))
        {
            _showPVM = new ShowPageViewModel();
        }
        #endregion

        #region Properties for Data Binding
        public IEnumerable<IDataWrapper<Show>> ShowList
        {
            get { return _showPVM.ItemCollection.Where(e => e.DataObject.MovieForShow.Key == FlowDataObject.ChosenMovie.Key); }
        }

        public IDataWrapper<Show> ShowSelected
        {
            get
            {
                return FlowDataObject.ChosenShow == null ? null : ShowList.FirstOrDefault(e => e.DataObject.Key == FlowDataObject.ChosenShow.Key);
            }
            set
            {
                FlowDataObject.ChosenShow = value.DataObject;
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
                $"At: {FlowDataObject.ChosenShow.TimeForShow.ToString()}");
            }
        } 
        #endregion
    }
}