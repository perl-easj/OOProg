namespace TestExampleC
{
    /// <summary>
    /// This interface contains methods for setting exchange rates,
    /// and for caluclating specific currency exchanges
    /// </summary>
    public interface ICurrencyExchange
    {
        /// <summary>
        /// Sets an exchange rate for the given currency cross
        /// </summary>
        void SetExchangeRate(string currencyCross, double exchangeRate);

        /// <summary>
        /// Performs an exchange calculation for the given 
        /// currency cross and amount.
        /// </summary>
        double DoExchange(string currencyCross, double amount);
    }
}