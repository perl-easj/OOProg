namespace FinanceSimulator
{
    /// <summary>
    /// This class can simulate a time series of prices 
    /// for a financial instrument (FI). A price time series 
    /// is specified by a price update interval and a 
    /// price generator.
    /// </summary>
    public class FinancialInstrumentSimulator
    {
        #region Instance fields
        private string _fiID;
        private IPriceGenerator _priceGenerator;
        private int _priceUpdateInterval;
        private double _currentPrice;
        private double _previousPrice;
        #endregion

        #region Constructor
        public FinancialInstrumentSimulator(string fiID, IPriceGenerator priceGenerator, int priceUpdateInterval = 1)
        {
            _fiID = fiID;
            _priceGenerator = priceGenerator;
            _priceUpdateInterval = priceUpdateInterval;
            _currentPrice = _priceGenerator.First();
            _previousPrice = _currentPrice;
        }
        #endregion

        #region Properties
        public string FIID
        {
            get { return _fiID; }
        }

        public double CurrentPrice
        {
            get { return _currentPrice; }
        }

        public double PreviousPrice
        {
            get { return _previousPrice; }
        }
        #endregion

        #region MyRegion
        /// <summary>
        /// This method will generate the next price in the price
        /// time series, if the time for generation for the next
        /// price has been reached.
        /// </summary>
        /// <param name="tick">Current time</param>
        /// <returns>True if price was actually updated, otherwise false.</returns>
        public bool UpdatePrice(int tick)
        {
            if (tick % _priceUpdateInterval == 0)
            {
                _previousPrice = _currentPrice;
                _currentPrice = _priceGenerator.Next(_currentPrice);
                return true;
            }

            return false;
        } 
        #endregion
    }
}