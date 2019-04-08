using System;
using System.Collections.Generic;

namespace StockTradeStrat.Shared
{
    /// <summary>
    /// This class can analyse a stream of stock quotes. It looks back at the
    /// latest "window" of quotes (defined by histLength), and finds:
    /// 1) The number of quote INCreases
    /// 2) The number of quote DECreases
    /// 3) The length of the current quote INCrease streak (if any)
    /// 4) The length of the current quote DeCrease streak (if any)
    /// </summary>
    public class StockQuoteAnalyser
    {
        public static StockQuoteHistory Analyse(List<double> quotes, int index, int histLength)
        {
            if (index < 0 || index >= quotes.Count)
            {
                throw new ArgumentException($"Index {index} not valid");
            }

            // Shorten analyse length if needed
            if (histLength > index) histLength = index;
            if (histLength == 0) return new StockQuoteHistory(index, 0);

            int incs = 0;
            int decs = 0;

            // Analyse for INCs and DECs
            for (int i = index; i > (index - histLength); i--)
            {
                if (quotes[i] > quotes[i - 1]) incs++;
                if (quotes[i] < quotes[i - 1]) decs++;
            }

            int incStreak = 0;
            int decStreak = 0;
            bool isIncStreak = quotes[index] > quotes[index - 1];
            bool streakRunning = true;

            // Analyse for streaks
            for (int i = index; i > (index - histLength) && streakRunning; i--)
            {
                if (quotes[i] > quotes[i - 1] && isIncStreak) incStreak++;
                else if (quotes[i] < quotes[i - 1] && !isIncStreak) decStreak++;
                else streakRunning = false;
            }

            return new StockQuoteHistory(index, histLength, incs, decs, incStreak, decStreak);
        }
    }
}