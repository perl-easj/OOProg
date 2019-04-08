using System.Collections.Generic;
using StockTradeStrat.Interfaces;
using StockTradeStrat.Shared;

namespace StockTradeStrat.WithStrategy.Strategies
{
    public class StockTradeStratDefDef : StockTradeStratBase, IStockTradeStrategy
    {
        // Defensive buy:
        //  1) If four of last changes were DECs, buy 10 % extra
        //  2) If three of last changes were DECs, buy 5 % extra
        // Defensive sell:
        //  3) If four of last changes were INCs, sell 10 % of owned
        //  4) If three of last changes were INCs, sell 5 % of owned
        public void Trade(IStockTrader trader, int index, List<double> quotes)
        {
            double quote = quotes[index];
            StockQuoteHistory sqHist = StockQuoteAnalyser.Analyse(quotes, index, HistoryLength);

            if (StratsLib.TryBuyOnMultiDec(trader, sqHist, quote, 4, 10)) return;
            if (StratsLib.TryBuyOnMultiDec(trader, sqHist, quote, 3, 20)) return;
            if (StratsLib.TrySellOnMultiInc(trader, sqHist, quote, 4, 10)) return;
            StratsLib.TrySellOnMultiInc(trader, sqHist, quote, 3, 20);
        }
    }
}