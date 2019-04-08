namespace StockTradeStrat.Interfaces
{
    /// <summary>
    /// Interface for creating stock trader objects
    /// implementing various trading strategies.
    /// </summary>
    public interface IStockTraderFactory
    {
        IStockTrader CreateAggrBuyAggrSell(string name, int noOfStocks, double firstQuote, double cash);
        IStockTrader CreateAggrBuyDefSell(string name, int noOfStocks, double firstQuote, double cash);
        IStockTrader CreateDefBuyAggrSell(string name, int noOfStocks, double firstQuote, double cash);
        IStockTrader CreateDefBuyDefSell(string name, int noOfStocks, double firstQuote, double cash);
    }
}