using System.Collections.Generic;

namespace StockTradeStrat.Interfaces
{
    /// <summary>
    /// This interface represents a stock trader. A stock trader will "act",
    /// i.e. respond to a sequence of stock quotes by selling/buying stocks.
    /// This is done according to a trading "strategy", defined in specific
    /// implementations of the interface.
    /// </summary>
    public interface IStockTrader
    {
        /// <summary>
        /// Act out the trading strategy on the given sequence of quotes.
        /// </summary>
        void Act(List<double> quotes);

        /// <summary>
        /// Try to buy stocks: Buy the specified amount of stocks,
        /// capped by the available cash amount.
        /// </summary>
        void TryToBuyStock(int noToBuy, double quote);

        /// <summary>
        /// Try to sell stocks: Sell the specified amount of stocks,
        /// capped by the currently owned number of stocks.
        /// </summary>
        void TryToSellStock(int noToSell, double quote);

        /// <summary>
        /// Number of stocks currently owned by the trader.
        /// </summary>
        int NoOfStocks { get; }

        /// <summary>
        /// Cash currently owned by the trader.
        /// </summary>
        double Cash { get; }

        /// <summary>
        /// Total value of assets (cash + stocks) owned by the trader.
        /// </summary>
        double Assets { get; }
    }
}