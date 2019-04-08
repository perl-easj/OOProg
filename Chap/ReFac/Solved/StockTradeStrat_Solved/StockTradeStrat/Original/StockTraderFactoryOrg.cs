using StockTradeStrat.Interfaces;

namespace StockTradeStrat.Original
{
    /// <summary>
    /// Specific implementation of IStockTraderFactory.
    /// Uses the original implementation of StockTrader.
    /// </summary>
    public class StockTraderFactoryOrg : IStockTraderFactory
    {
        public IStockTrader CreateAggrBuyAggrSell(string name, int noOfStocks, double firstQuote, double cash)
        {
            return new StockTraderOrg(name, noOfStocks, firstQuote, cash, true, true);
        }

        public IStockTrader CreateAggrBuyDefSell(string name, int noOfStocks, double firstQuote, double cash)
        {
            return new StockTraderOrg(name, noOfStocks, firstQuote, cash, true, false);
        }

        public IStockTrader CreateDefBuyAggrSell(string name, int noOfStocks, double firstQuote, double cash)
        {
            return new StockTraderOrg(name, noOfStocks, firstQuote, cash, false, true);
        }

        public IStockTrader CreateDefBuyDefSell(string name, int noOfStocks, double firstQuote, double cash)
        {
            return new StockTraderOrg(name, noOfStocks, firstQuote, cash, false, false);
        }
    }
}