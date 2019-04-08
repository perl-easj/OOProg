using System;
using System.Collections.Generic;

namespace StockTradeStrat.Shared
{
    /// <summary>
    /// This class can generate a sequence of stock quotes, controlled by a set of parameters.
    /// minQuote: minimal valid value for quote
    /// maxQuote: maximal valid value for quote
    /// maxChange: maximal (in percent) possible change for subsequent quote value
    /// </summary>
    public class StockQuoteGenerator
    {
        private static Random _rng;
        private int _noOfQuotes;
        private double _minQuote;
        private double _maxQuote;
        private double _maxChange;

        public string Symbol { get; }
        public List<double> Quotes { get; }

        public StockQuoteGenerator(string symbol, int noOfQuotes, double minQuote, double maxQuote, double maxChange, int seed = 0)
        {
            Symbol = symbol;
            Quotes = new List<double>(); 

            _noOfQuotes = noOfQuotes;
            _minQuote = minQuote;
            _maxQuote = maxQuote;
            _maxChange = maxChange;

            Init(seed);
            Generate();
        }

        /// <summary>
        /// Using a seed which is NOT zero will
        /// always generate the same stream.
        /// </summary>
        private void Init(int seed)
        {
            _rng = seed == 0 ? new Random(Guid.NewGuid().GetHashCode()) : new Random(seed);
        }

        private void Generate()
        {
            // Initial quote is just average of valid max and min.
            Quotes.Add((_minQuote + _maxQuote) / 2.0);

            for (int i = 1; i < _noOfQuotes; i++)
            {
                Quotes.Add(NextQuote(Quotes[i - 1]));
            }
        }

        private double NextQuote(double currentQuote)
        {
            double change = _maxChange * ((2 * _rng.NextDouble()) - 1.0);
            double nextQuote = currentQuote + ((currentQuote * change) / 100.0);

            if (nextQuote < _minQuote) nextQuote = _minQuote;
            if (nextQuote > _maxQuote) nextQuote = _maxQuote;

            return nextQuote;
        }

        public override string ToString()
        {
            string sqStr = $"Quotes for {Symbol} :\n";
            Quotes.ForEach(q => { sqStr += $"{q:F3}\n"; });
            return sqStr;
        }
    }
}