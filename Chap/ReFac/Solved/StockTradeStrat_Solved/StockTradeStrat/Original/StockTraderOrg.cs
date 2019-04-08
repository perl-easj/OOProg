using System.Collections.Generic;
using StockTradeStrat.Interfaces;
using StockTradeStrat.Shared;

namespace StockTradeStrat.Original
{
    /// <summary>
    /// In this implementation, the trading strategy is defined by
    /// two boolean variables:
    ///   AggrBuy : Aggressive Buy (false implies "Defensive Buy")
    ///   AggrSell : Aggressive Sell (false implies "Defensive Sell")
    /// </summary>
    public class StockTraderOrg : StockTraderBase, IStockTrader
    {
        public bool AggrBuy { get; private set; }
        public bool AggrSell { get; private set; }

        public StockTraderOrg(string name, int noOfStocks,double firstQuote, double cash, bool aggrBuy, bool aggrSell) 
            : base(name, noOfStocks, firstQuote, cash)
        {
            AggrBuy = aggrBuy;
            AggrSell = aggrSell;
        }

        /// <summary>
        /// This is the specific implementation of the four (currently) existing
        /// trade strategies, found by combining aggressive/defensive strategies
        /// for buying/selling. NB: The "quality" of the strategies as such is not
        /// of importance here :-).
        /// </summary>
        protected override void Trade(int index, List<double> quotes)
        {
            int histLength = 5; // All strategies look five quotes back.

            double quote = quotes[index];
            StockQuoteHistory sqHist = StockQuoteAnalyser.Analyse(quotes, index, histLength);

            // Aggressive buy:
            //  1) If three or more DECs in a row, buy 20 % extra
            //  2) If two or more DECs in a row, buy 10 % extra
            // Aggressive sell:
            //  3) If three or more INCs in a row, sell 20 % of owned
            //  4) If two or more INCs in a row, sell 10 % of owned
            if (AggrBuy && AggrSell)
            {
                if (sqHist.DecStreak >= 3)
                {
                    TryToBuyStock(NoOfStocks / 5, quote);
                }
                else if (sqHist.DecStreak >= 2)
                {
                    TryToBuyStock(NoOfStocks / 10, quote);
                }
                else if (sqHist.IncStreak >= 3)
                {
                    TryToSellStock(NoOfStocks/5, quote);
                }
                else if (sqHist.IncStreak >= 2)
                {
                    TryToSellStock(NoOfStocks / 10, quote);
                }
            }

            // Defensive buy:
            //  1) If four of last changes were DECs, buy 10 % extra
            //  2) If three of last changes were DECs, buy 5 % extra
            // Aggressive sell:
            //  3) If three or more INCs in a row, sell 20 % of owned
            //  4) If two or more INCs in a row, sell 10 % of owned
            if (!AggrBuy && AggrSell)
            {
                if (sqHist.Decs >= 4)
                {
                    TryToBuyStock(NoOfStocks / 10, quote);
                }
                else if (sqHist.Decs >= 3)
                {
                    TryToBuyStock(NoOfStocks / 20, quote);
                }
                else if (sqHist.IncStreak >= 3)
                {
                    TryToSellStock(NoOfStocks / 5, quote);
                }
                else if (sqHist.IncStreak >= 2)
                {
                    TryToSellStock(NoOfStocks / 10, quote);
                }
            }

            // Aggressive buy:
            //  1) If three or more DECs in a row, buy 20 % extra
            //  2) If two or more DECs in a row, buy 10 % extra
            // Defensive sell:
            //  3) If four of last changes were INCs, sell 10 % of owned
            //  4) If three of last changes were INCs, sell 5 % of owned
            if (AggrBuy && !AggrSell)
            {
                if (sqHist.DecStreak >= 3)
                {
                    TryToBuyStock(NoOfStocks / 5, quote);
                }
                else if (sqHist.DecStreak >= 2)
                {
                    TryToBuyStock(NoOfStocks / 10, quote);
                }
                else if (sqHist.Incs >= 4)
                {
                    TryToSellStock(NoOfStocks / 10, quote);
                }
                else if (sqHist.Incs >= 3)
                {
                    TryToSellStock(NoOfStocks / 20, quote);
                }
            }

            // Defensive buy:
            //  1) If four of last changes were DECs, buy 10 % extra
            //  2) If three of last changes were DECs, buy 5 % extra
            // Defensive sell:
            //  3) If four of last changes were INCs, sell 10 % of owned
            //  4) If three of last changes were INCs, sell 5 % of owned
            if (!AggrBuy && !AggrSell)
            {
                if (sqHist.Decs >= 4)
                {
                    TryToBuyStock(NoOfStocks / 10, quote);
                }
                else if (sqHist.Decs >= 3)
                {
                    TryToBuyStock(NoOfStocks / 20, quote);
                }
                else if (sqHist.Incs >= 4)
                {
                    TryToSellStock(NoOfStocks / 10, quote);
                }
                else if (sqHist.Incs >= 3)
                {
                    TryToSellStock(NoOfStocks / 20, quote);
                }
            }
        }
    }
}