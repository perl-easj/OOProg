using System;
using System.Collections.Generic;

namespace StockTradeStrat.Shared
{
    /// <summary>
    /// Base class for a stock trader. This class does NOT implement
    /// trading strategies in any specific way.
    /// </summary>
    public abstract class StockTraderBase
    {
        public string Name { get; }
        public int NoOfStocks { get; protected set; }
        public double Cash { get; protected set; }
        public double LastQuote { get; private set; }
        public List<string> TradeLog { get; }
        public double Assets { get { return Cash + (LastQuote * NoOfStocks); } }

        protected StockTraderBase(string name, int noOfStocks, double firstQuote, double cash)
        {
            Name = name;
            NoOfStocks = noOfStocks;
            Cash = cash;
            TradeLog = new List<string>();
            LastQuote = firstQuote;
        }

       /// <summary>
        /// Act simply calls Trade for each quote in the quote sequence,
        /// but Trade itself is abstract (Hello, Template Method pattern :-))
        /// </summary>
        public void Act(List<double> quotes)
        {
            for (int index = 0; index < quotes.Count; index++)
            {
                Trade(index, quotes);
            }

            LastQuote = quotes[quotes.Count - 1];
        }

        protected abstract void Trade(int index, List<double> quotes);

        public void TryToBuyStock(int noToBuy, double quote)
        {
            int noCanBuy = (int)Math.Floor(Cash / quote);
            if (noToBuy > noCanBuy) noToBuy = noCanBuy;

            Cash -= noToBuy * quote;
            NoOfStocks += noToBuy;

            Log("Buy", noToBuy, quote);
        }

        public void TryToSellStock(int noToSell, double quote)
        {
            if (noToSell > NoOfStocks) noToSell = NoOfStocks;

            Cash += noToSell * quote;
            NoOfStocks -= noToSell;

            Log("Sell", noToSell, quote);
        }

        private void Log(string desc, int noOfStocks, double quote)
        {
            string logEntry = $"{desc} {noOfStocks} stocks @ {quote:F3}";
            TradeLog.Add(logEntry);
        }

        public override string ToString()
        {
            return $"{Name} has {NoOfStocks} stocks @{LastQuote:F3} and {Cash:F1} kr. = {Assets:F1} kr. (did {TradeLog.Count} trades)";
        }
    }
}