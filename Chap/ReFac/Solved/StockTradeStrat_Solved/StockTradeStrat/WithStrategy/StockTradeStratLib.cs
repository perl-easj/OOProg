using System;
using StockTradeStrat.Interfaces;
using StockTradeStrat.Shared;

namespace StockTradeStrat.WithStrategy
{
    /// <summary>
    /// This class contain various utility functions, for use in
    /// specific trade strategy implementations.
    /// </summary>
    public class StockTradeStratLib
    {
        public bool TryBuyOnDecStreak(IStockTrader trader, StockQuoteHistory sqHist, double quote, int streakLength, int fraction)
        {
            return TradeConditional(trader, () => sqHist.DecStreak >= streakLength, trader.TryToBuyStock, quote, fraction);
        }

        public bool TrySellOnIncStreak(IStockTrader trader, StockQuoteHistory sqHist, double quote, int streakLength, int fraction)
        {
            return TradeConditional(trader, () => sqHist.IncStreak >= streakLength, trader.TryToSellStock, quote, fraction);
        }

        public bool TryBuyOnMultiDec(IStockTrader trader, StockQuoteHistory sqHist, double quote, int noOfDecs, int fraction)
        {
            return TradeConditional(trader, () => sqHist.Decs >= noOfDecs, trader.TryToBuyStock, quote, fraction);
        }

        public bool TrySellOnMultiInc(IStockTrader trader, StockQuoteHistory sqHist, double quote, int noOfIncs, int fraction)
        {
            return TradeConditional(trader, () => sqHist.Incs >= noOfIncs, trader.TryToSellStock, quote, fraction);
        }

        /// <summary>
        /// General implementation of the "trade-if-condition" code idiom.
        /// </summary>
        private bool TradeConditional(IStockTrader trader, Func<bool> condition, Action<int, double> tradeFunc, double quote, int fraction)
        {
            if (!condition()) return false;

            tradeFunc(trader.NoOfStocks / fraction, quote);
            return true;

        }
    }
}