using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace FinanceSimulator
{
    /// <summary>
    /// View model for a single quote. Note that the 
    /// view model is a consumer of quotes.
    /// </summary>
    public class QuoteViewModel : INotifyPropertyChanged, IQuoteConsumer
    {
        #region Instance fields
        private Quote _quote;
        private double _previousPrice;
        #endregion

        #region Constructor
        public QuoteViewModel(Quote q)
        {
            _quote = q;
            _previousPrice = q.Price;
        }
        #endregion

        #region Properties (used for Data Binding)
        public string FiID
        {
            get { return _quote.FiID; }
        }

        public double Price
        {
            get { return _quote.Price; }
            private set
            {
                // Store the current price in the _previousPrice field,
                // since we need it to determine text coloring.
                _previousPrice = _quote.Price;
                _quote.Price = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(PriceColor));
                OnPropertyChanged(nameof(PriceStr));
            }
        }

        public string PriceStr
        {
            get { return $"{Price:F2}"; }
        }

        public SolidColorBrush PriceColor
        {
            get { return new SolidColorBrush(Price - _previousPrice < 0 ? Colors.Crimson : Colors.DarkGreen); }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Consumes quotes, but only reacts to quotes 
        /// for which the FiID matches.
        /// </summary>
        /// <param name="q">Incoming quote</param>
        public void ConsumeQuote(Quote q)
        {
            if (q.FiID == FiID)
            {
                Price = q.Price;
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