namespace TestExampleC
{
    /// <summary>
    /// This interface contains methods for validating
    /// currency identifiers and currency crosses.
    /// </summary>
    public interface ICurrencyCheck
    {
        /// <summary>
        /// Validates the given currency identifier
        /// </summary>
        bool IsValidCurrencyID(string currencyID);

        /// <summary>
        /// Validates the given currency cross
        /// </summary>
        bool IsValidCurrencyCross(string currencyCross);
    }
}