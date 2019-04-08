namespace StockTradeStrat.WithStrategy
{
    /// <summary>
    /// Base class for trade strategy implementations. Mainly contains
    /// a reference to the function library, plus some default setup.
    /// </summary>
    public class StockTradeStratBase
    {
        private const int DefaultHistoryLength = 5;
        protected int HistoryLength { get { return DefaultHistoryLength; } }
        protected StockTradeStratLib StratsLib { get; }

        public StockTradeStratBase()
        {
            StratsLib = new StockTradeStratLib();
        }
    }
}