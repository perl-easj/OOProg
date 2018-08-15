using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace FinanceSimulator
{
    /// <summary>
    /// View model for a single stock. Note that the 
    /// view model is a consumer of quotes.
    /// </summary>
    public class StockViewModel : INotifyPropertyChanged, IQuoteConsumer
    {
        #region Instance fields
        private Stock _stock;
        private double _currentPrice;
        #endregion

        #region Constructor
        public StockViewModel(Stock sd, double currentPrice)
        {
            _stock = sd;
            _currentPrice = currentPrice;
        }
        #endregion

        #region Properties (used for Data Binding)
        public string FiID
        {
            get { return _stock.FiID; }
        }

        public string FullName
        {
            get { return _stock.FullName; }
        }

        public double AllTimeLow
        {
            get { return _stock.AllTimeLow; }
        }

        public double AllTimeHigh
        {
            get { return _stock.AllTimeHigh; }
        }

        public double PercentChange
        {
            get { return ((CurrentPrice - _stock.InitialPrice) / _stock.InitialPrice) * 100.0; }
        }

        public double InitialPrice
        {
            get { return _stock.InitialPrice; }
        }

        public double CurrentPrice
        {
            get { return _currentPrice; }
            private set
            {
                _currentPrice = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CurrentPriceStr));
                OnPropertyChanged(nameof(AllTimeLowHighStr));
                OnPropertyChanged(nameof(PercentChangeColor));
                OnPropertyChanged(nameof(PercentChangeStr));
            }
        }

        public string AllTimeLowHighStr
        {
            get { return $"{AllTimeLow:F2} / {AllTimeHigh:F2}"; }
        }

        public string PercentChangeStr
        {
            get { return $"({PercentChange:F2} %)"; }
        }

        public SolidColorBrush PercentChangeColor
        {
            get { return new SolidColorBrush(PercentChange < 0 ? Colors.Crimson : Colors.DarkGreen); }
        }

        public string CurrentPriceStr
        {
            get { return $"{CurrentPrice:F2}"; }
        }

        public string InitialPriceStr
        {
            get { return $"{InitialPrice:F2}"; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// If an incoming quote is a match on FiID, the quote
        /// is forwarded to the encapsulated Stock object.
        /// The current price is also updated.
        /// </summary>
        /// <param name="q">Incoming quote</param>
        public void ConsumeQuote(Quote q)
        {
            if (q.FiID == FiID)
            {
                _stock.ConsumeQuote(q);
                CurrentPrice = q.Price;
            }
        } 
        #endregion

        #region INotifyPropertyChanged code
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
    }
}