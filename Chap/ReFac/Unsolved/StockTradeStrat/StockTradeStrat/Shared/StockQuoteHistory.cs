namespace StockTradeStrat.Shared
{
    /// <summary>
    /// Simple data carrying object for reporting a
    /// stock quote history analysis.
    /// </summary>
    public class StockQuoteHistory
    {
        public int Index { get; }
        public int Length { get; }
        public int Incs { get; }
        public int Decs { get; }
        public int IncStreak { get; }
        public int DecStreak { get; }

        public StockQuoteHistory(int index, int length, int incs, int decs, int incStreak, int decStreak)
        {
            Index = index;
            Length = length;
            Incs = incs;
            Decs = decs;
            IncStreak = incStreak;
            DecStreak = decStreak;
        }

        public StockQuoteHistory(int index, int length)
        {
            Index = index;
            Length = length;
            Incs = 0;
            Decs = 0;
            IncStreak = 0;
            DecStreak = 0;
        }

        public override string ToString()
        {
            return $"Index {Index}, Length {Length} :  Incs: {Incs}  Decs: {Decs}, Inc+: {IncStreak}, Dec+: {DecStreak}";
        }
    }
}