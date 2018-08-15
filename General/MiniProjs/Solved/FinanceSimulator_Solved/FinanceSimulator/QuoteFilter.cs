using System;

namespace FinanceSimulator
{
    /// <summary>
    /// Base class for any class capable of filtering a stream of quotes.
    /// The class will receive quotes through the ConsumeQuote method,
    /// apply a filtering criterion, and relay all quotes passing the
    /// filter by raising its Quotes event.
    /// </summary>
    public abstract class QuoteFilter : IQuoteStream, IQuoteConsumer
    {
        public event Action<Quote> Quotes;

        #region Constructor
        protected QuoteFilter()
        {
            Quotes = null;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Consume a quote, and pass it on if the quote
        /// meets the filtering condition.
        /// </summary>
        /// <param name="q">Incoming quote</param>
        public void ConsumeQuote(Quote q)
        {
            if (ApplyFilter(q))
            {
                Quotes?.Invoke(q);
            }
        }

        /// <summary>
        /// Filtering condition. Specific implementations are
        /// deferred to classes inheriting from QuoteFilter
        /// </summary>
        /// <param name="q">Incoming quote</param>
        /// <returns>True if quote meets filtering condition, otherwise false.</returns>
        public abstract bool ApplyFilter(Quote q); 
        #endregion
    }
}