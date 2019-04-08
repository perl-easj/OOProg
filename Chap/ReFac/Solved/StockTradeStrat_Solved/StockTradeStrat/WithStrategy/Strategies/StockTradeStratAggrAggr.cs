using System.Collections.Generic;
using StockTradeStrat.Interfaces;
using StockTradeStrat.Shared;

namespace StockTradeStrat.WithStrategy.Strategies
{
    public class StockTradeStratAggrAggr : StockTradeStratBase, IStockTradeStrategy
    {
        // Aggressive buy:
        //  1) If three or more DECs in a row, buy 20 % extra
        //  2) If two or more DECs in a row, buy 10 % extra
        // Aggressive sell:
        //  3) If three or more INCs in a row, sell 20 % of owned
        //  4) If two or more INCs in a row, sell 10 % of owned
        public void Trade(IStockTrader trader, int index, List<double> quotes)
        {
            double quote = quotes[index];
            StockQuoteHistory sqHist = StockQuoteAnalyser.Analyse(quotes, index, HistoryLength);

            if (StratsLib.TryBuyOnDecStreak(trader, sqHist, quote, 3, 5)) return;
            if (StratsLib.TryBuyOnDecStreak(trader, sqHist, quote, 2, 10)) return;
            if (StratsLib.TrySellOnIncStreak(trader, sqHist, quote, 3, 5)) return;
            StratsLib.TrySellOnIncStreak(trader, sqHist, quote, 2, 10);
        }
    }
}