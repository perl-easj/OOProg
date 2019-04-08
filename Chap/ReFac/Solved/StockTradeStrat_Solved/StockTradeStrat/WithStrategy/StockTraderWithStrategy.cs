using System.Collections.Generic;
using StockTradeStrat.Interfaces;
using StockTradeStrat.Shared;

namespace StockTradeStrat.WithStrategy
{
    /// <summary>
    /// In this implementation, the trading strategy is injected
    /// into the trader, as a referece of type IStockTradeStrategy
    /// </summary>
    public class StockTraderWithStrategy : StockTraderBase, IStockTrader
    {
        protected IStockTradeStrategy _tradeStrategy;
        public StockTraderWithStrategy(string name, int noOfStocks, double firstQuote, double cash, IStockTradeStrategy tradeStrategy) 
            : base(name, noOfStocks, firstQuote, cash)
        {
            _tradeStrategy = tradeStrategy;
        }

        /// <summary>
        /// Simply forwards the call to the injected strategy object,
        /// including a reference to the trader itself, since this is
        /// the "context" for a trading strategy.
        /// </summary>
        protected override void Trade(int index, List<double> quotes)
        {
            _tradeStrategy.Trade(this, index, quotes);
        }
    }
}