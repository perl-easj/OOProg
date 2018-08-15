namespace StockPortfolio
{
    /// <summary>
    /// This class represents a stock holding, defined 
    /// by a stock name and an amount of stocks owned.
    /// The price of the stock can be updated after creation.
    /// The initial price for the stock can always be 
    /// retrieved through the property InitialPrice.
    /// </summary>
    public class Stock
    {
        #region Instance fields
        private string _name;
        private int _amount;
        private double _initialPrice;
        private double _currentPrice;
        #endregion

        #region Constructor
        public Stock(string name, int amount, double initialPrice)
        {
            _name = name;
            _amount = amount;
            _initialPrice = initialPrice;
            _currentPrice = _initialPrice;
        }
        #endregion

        #region Properties
        public string Name
        {
            get { return _name; }
        }

        public int Amount
        {
            get { return _amount; }
        }

        public double InitialPrice
        {
            get { return _initialPrice; }
        }

        public double CurrentPrice
        {
            get { return _currentPrice; }
            set { _currentPrice = value; }
        } 
        #endregion
    }
}