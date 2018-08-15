namespace StockTrade
{
    /// <summary>
    /// This class is a very simplified model for a stock trader.
    /// A stock trader will trade (buy or sell) a single stock,
    /// whenever the stock price is above/below a given limit.
    /// </summary>
    public class StockTrader
    {
        #region Instance fields
        private string _name;
        private string _id;
        private double _limit;
        private bool _buy;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new StockTrader object.
        /// </summary>
        /// <param name="name">
        /// Name of stock trader (e.g. James)
        /// </param>
        /// <param name="id">
        /// Stock identifier
        /// </param>
        /// <param name="limit">
        /// Stock price limit (upper for buy, lower for sell)
        /// </param>
        /// <param name="buy">
        /// Buy or sell. True means buy, false means sell.
        /// </param>
        public StockTrader(string name, string id, double limit, bool buy)
        {
            _name = name;
            _id = id;
            _limit = limit;
            _buy = buy;
        } 
        #endregion

        /// <summary>
        /// This method can be registered at events for
        /// stock price changes. 
        /// </summary>
        /// <param name="id">
        /// Stock identifier.
        /// </param>
        /// <param name="price">
        /// New stock price.
        /// </param>
        public void DoTrade(string id, double price)
        {
            if (id == _id)
            {
                if (_buy && price <= _limit) // Condition for Buy
                {
                    TradeLog.Log.Add($"{_name} bought {id} @ {price:0.00}");
                }

                if (!_buy && price >= _limit) // Condition for Sell
                {
                    TradeLog.Log.Add($"{_name} sold {id} @ {price:0.00}");
                }
            }
        }
    }
}