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
    /// Flow view model for the first step in the "Buy Ticket" flow.
    /// In this step, the user selects a Movie.
    /// </summary>
    public class BuyTicketFlowViewModelStart : FlowViewModelStart<TicketDataViewModel> 
    {
        #region Instance fields
        private MoviePageViewModel _moviePVM;
        #endregion

        #region Constructor
        public BuyTicketFlowViewModelStart()
            : base(AppViewModelBase.AppFrameInstance, typeof(BuyTicketViewA))
        {
            _moviePVM = new MoviePageViewModel();
        }
        #endregion

        #region Properties for Data Binding
        public IEnumerable<IDataWrapper<Movie>> MovieList
        {
            get { return _moviePVM.ItemCollection; }
        }

        public IDataWrapper<Movie> MovieSelected
        {
            get
            {
                return FlowDataObject.ChosenMovie == null ? null : MovieList.FirstOrDefault(e => e.DataObject.Key == FlowDataObject.ChosenMovie.Key);
            }
            set
            {
                FlowDataObject.ChosenMovie = value.DataObject;
                OnPropertyChanged();
                OnPropertyChanged(nameof(StatusText));
            }
        }

        public string StatusText
        {
            get { return (FlowDataObject.ChosenMovie == null ? "No Movie selected..." : $"Selected: {FlowDataObject.ChosenMovie.Title}"); }
        } 
        #endregion
    }
}