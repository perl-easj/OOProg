using System.Collections.Generic;
using StockTradeStrat.Interfaces;
using StockTradeStrat.Shared;

namespace StockTradeStrat.WithStrategy.Strategies
{
    public class StockTradeStratAggrDef : StockTradeStratBase, IStockTradeStrategy
    {
        // Aggressive buy:
        //  1) If three or more DECs in a row, buy 20 % extra
        //  2) If two or more DECs in a row, buy 10 % extra
        // Defensive sell:
        //  3) If four of last changes were INCs, sell 10 % of owned
        //  4) If three of last changes were INCs, sell 5 % of owned
        public void Trade(IStockTrader trader, int index, List<double> quotes)
        {
            double quote = quotes[index];
            StockQuoteHistory sqHist = StockQuoteAnalyser.Analyse(quotes, index, HistoryLength);

            if (StratsLib.TryBuyOnDecStreak(trader, sqHist, quote, 3, 5)) return;
            if (StratsLib.TryBuyOnDecStreak(trader, sqHist, quote, 2, 10)) return;
            if (StratsLib.TrySellOnMultiInc(trader, sqHist, quote, 4, 10)) return;
            StratsLib.TrySellOnMultiInc(trader, sqHist, quote, 3, 20);
        }
    }
}