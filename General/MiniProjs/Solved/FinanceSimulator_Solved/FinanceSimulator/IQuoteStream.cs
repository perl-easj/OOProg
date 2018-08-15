using System;

namespace FinanceSimulator
{
    /// <summary>
    /// Interface for any class generating quotes.
    /// </summary>
    public interface IQuoteStream
    {
        /// <summary>
        /// Event which will be raised whenever a new quote 
        /// is available. The quote itself will be a parameter
        /// to the event.
        /// </summary>
        event Action<Quote> Quotes;
    }
}