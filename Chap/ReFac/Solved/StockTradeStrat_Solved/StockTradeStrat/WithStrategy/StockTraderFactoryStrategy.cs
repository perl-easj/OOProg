using StockTradeStrat.Interfaces;
using StockTradeStrat.WithStrategy.Strategies;

namespace StockTradeStrat.WithStrategy
{
    /// <summary>
    /// Specific implementation of IStockTraderFactory.
    /// Uses the strategy-oriented implementation of StockTrader.
    /// The factory is responsible for injecting a specific
    /// trading strategy object into the trader object.
    /// </summary>
    public class StockTraderFactoryStrategy : IStockTraderFactory
    {
        public IStockTrader CreateAggrBuyAggrSell(string name, int noOfStocks, double firstQuote, double cash)
        {
            return Create(name, noOfStocks, firstQuote, cash, new StockTradeStratAggrAggr());
        }

        public IStockTrader CreateAggrBuyDefSell(string name, int noOfStocks, double firstQuote, double cash)
        {
            return Create(name, noOfStocks, firstQuote, cash, new StockTradeStratAggrDef());
        }

        public IStockTrader CreateDefBuyAggrSell(string name, int noOfStocks, double firstQuote, double cash)
        {
            return Create(name, noOfStocks, firstQuote, cash, new StockTradeStratDefAggr());
        }

        public IStockTrader CreateDefBuyDefSell(string name, int noOfStocks, double firstQuote, double cash)
        {
            return Create(name, noOfStocks, firstQuote, cash, new StockTradeStratDefDef());
        }

        private IStockTrader Create(string name, int noOfStocks, double firstQuote, double cash, IStockTradeStrategy strat)
        {
            return new StockTraderWithStrategy(name, noOfStocks, firstQuote, cash, strat);
        }
    }
}