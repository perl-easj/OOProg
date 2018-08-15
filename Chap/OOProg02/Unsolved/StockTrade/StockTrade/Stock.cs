using System;

namespace StockTrade
{
    /// <summary>
    /// This class is intended to simulate a stock, including
    /// simulating changes in stock price.
    /// </summary>
    public class Stock
    {
        #region Instance fields
        private string _id;
        private double _price;
        private double _lowerLimit;
        private double _upperLimit;
        private Random _generator;
        public event Action<string, double> PriceChanged;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new Stock object
        /// </summary>
        /// <param name="id">
        /// Stock identifier, e.g. MSFT
        /// </param>
        /// <param name="lowerLimit">
        /// Lower limit for stock price
        /// </param>
        /// <param name="upperLimit">
        /// Upper limit for stock price
        /// </param>
        public Stock(string id, double lowerLimit, double upperLimit)
        {
            // Sanity check
            if (lowerLimit > upperLimit)
            {
                throw new ArgumentException("lowerLimit must be lower than upperLimit!");
            }

            _id = id;
            _lowerLimit = lowerLimit;
            _upperLimit = upperLimit;
            _generator = new Random(Guid.NewGuid().GetHashCode());

            Price = (_upperLimit + _lowerLimit) / 2;
            PriceChanged = null;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Current stock price
        /// </summary>
        public double Price
        {
            get { return _price; }
            private set { _price = value; }
        }

        /// <summary>
        /// Stock identifier (ticker)
        /// </summary>
        public string ID
        {
            get { return _id; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Simulates a change in stock price. Rules are:
        /// 1) New price is within -/+ 10 % of the current price.
        /// 2) New price must be at most equal to upper limit.
        /// 3) New price must be at least equal to lower limit.
        /// </summary>
        public void GenerateNewPrice()
        {
            int percentChange = 10 - _generator.Next(21);
            double factor = 1 + (percentChange / 100.0);

            double newPrice = _price * factor;

            if (newPrice > _upperLimit)
            {
                newPrice = _upperLimit;
            }

            if (newPrice < _lowerLimit)
            {
                newPrice = _lowerLimit;
            }

            Price = newPrice;
            PriceChanged?.Invoke(ID, Price);
        }

        /// <summary>
        /// Convenient ToString, for easy printing.
        /// </summary>
        public override string ToString()
        {
            return $"{ID} : {Price:0.00}";
        } 
        #endregion
    }
}