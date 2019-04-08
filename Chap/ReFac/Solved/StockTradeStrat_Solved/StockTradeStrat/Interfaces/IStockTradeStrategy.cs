using System.Collections.Generic;

namespace StockTradeStrat.Interfaces
{
    public interface IStockTradeStrategy
    {
        void Trade(IStockTrader trader, int index, List<double> quotes);
    }
}