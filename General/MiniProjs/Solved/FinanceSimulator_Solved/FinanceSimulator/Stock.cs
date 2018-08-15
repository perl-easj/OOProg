namespace FinanceSimulator
{
    /// <summary>
    /// This class simulates a real-world stock. The price of
    /// the stock can only move within a specified interval.
    /// The stock also keeps track of the highest and lowest
    /// price ever seen since the stock was created.
    /// </summary>
    public class Stock : FinancialInstrument, IQuoteConsumer
    {
        #region Instance fields
        private string _fullName;
        private double _initialPrice;
        private double _minPrice;
        private double _maxPrice;
        private double _allTimeLow;
        private double _allTimeHigh;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fiID">FI-identifier</param>
        /// <param name="fullName">Full name of stock (e.g. company name)</param>
        /// <param name="minPrice">Minimal valid price for stock</param>
        /// <param name="maxPrice">Maximal valid price for stock</param>
        public Stock(string fiID, string fullName, double minPrice, double maxPrice)
                : base(fiID, Type.Stock)
        {
            _fullName = fullName;
            _initialPrice = (minPrice + maxPrice) / 2;
            _minPrice = minPrice;
            _maxPrice = maxPrice;
            _allTimeLow = _initialPrice;
            _allTimeHigh = _initialPrice;
        }
        #endregion

        #region Properties
        public string FullName
        {
            get { return _fullName; }
        }

        public double AllTimeLow
        {
            get { return _allTimeLow; }
        }

        public double AllTimeHigh
        {
            get { return _allTimeHigh; }
        }

        public double InitialPrice
        {
            get { return _initialPrice; }
        }

        public double MinPrice
        {
            get { return _minPrice; }
        }

        public double MaxPrice
        {
            get { return _maxPrice; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// When a quote (with matching fiID) is received,
        /// the all-time high and low are updated if needed.
        /// </summary>
        /// <param name="q"></param>
        public void ConsumeQuote(Quote q)
        {
            if (q.FiID == FiID)
            {
                _allTimeLow = q.Price < _allTimeLow ? q.Price : _allTimeLow;
                _allTimeHigh = q.Price > _allTimeHigh ? q.Price : _allTimeHigh;
            }
        } 
        #endregion
    }
}