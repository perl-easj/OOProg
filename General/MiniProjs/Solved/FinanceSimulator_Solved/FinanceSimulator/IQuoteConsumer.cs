namespace FinanceSimulator
{
    /// <summary>
    /// Interface for any class interested in "consuming" a quote.
    /// </summary>
    public interface IQuoteConsumer
    {
        /// <summary>
        /// Method to be called when a new quote is available.
        /// Will typically be bound to a quote generating event.
        /// </summary>
        /// <param name="q">Quote object to consume</param>
        void ConsumeQuote(Quote q);
    }
}