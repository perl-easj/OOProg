using BioDemo.Data.Domain;
using BioDemo.ViewModels.Base;

namespace BioDemo.ViewModels.Data
{
    /// <summary>
    /// Data view model class for Ticket objects. Mainly provides
    /// properties for single-object Data Binding in the Ticket view.
    /// Note that even though this class contains properties for chosen
    /// Movie and Show, it does NOT contain properties for providing
    /// lists of these objects. This is because Ticket object are created
    /// through a "flow", meaning that selection of Movie/Show is handled
    /// in the corresponding FlowViewModel classes.
    /// </summary>
    public class TicketDataViewModel : DataViewModelAppBase<Ticket>
    {
        #region Instance fields
        private Movie _chosenMovie;
        #endregion

        #region Constructors
        public TicketDataViewModel() : this(new Ticket())
        {
        }

        public TicketDataViewModel(Ticket obj) : base(obj)
        {
            _chosenMovie = null;
        }
        #endregion

        #region Properties
        public Movie ChosenMovie
        {
            get { return _chosenMovie; }
            set
            {
                _chosenMovie = value;
                OnPropertyChanged();
            }
        }

        public Show ChosenShow
        {
            get { return DataObject.ShowForTicket; }
            set
            {
                DataObject.ShowKey = value.Key;
                OnPropertyChanged();
            }
        }

        public int Row
        {
            get { return DataObject.Row; }
            set
            {
                DataObject.Row = value;
                OnPropertyChanged();
            }
        }

        public int Seat
        {
            get { return DataObject.Seat; }
            set
            {
                DataObject.Seat = value;
                OnPropertyChanged();
            }
        }

        public string Title
        {
            get { return ChosenShow?.MovieForShow?.Title; }
        }

        public string Theater
        {
            get { return ChosenShow?.TheaterForShow?.Description; }
        }

        public string ShowTime
        {
            get { return $"{ChosenShow?.DateForShow.ToLongDateString()} at {ChosenShow?.TimeForShow.Hours:00}:{ChosenShow?.TimeForShow.Minutes:00}"; }
        }

        public string Seating
        {
            get { return $"Row {Row}, Seat {Seat}"; }
        }

        public override string HeaderText
        {
            get { return $"{Title} ({Theater})"; }
        }

        public override string ContentText
        {
            get { return $"{ChosenShow?.DateForShow.ToShortDateString()}@{ChosenShow?.TimeForShow.ToString()} (R{Row}S{Seat})"; }
        } 
        #endregion
    }
}