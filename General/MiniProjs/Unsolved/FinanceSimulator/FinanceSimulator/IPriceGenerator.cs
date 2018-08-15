namespace FinanceSimulator
{
    /// <summary>
    /// Interface for a price time series generator. A time series
    /// is simply a series of numeric values, where the next value
    /// is generated based on the previous value.
    /// </summary>
    public interface IPriceGenerator
    {
        /// <summary>
        /// Generates the first value in the time series
        /// </summary>
        /// <returns>Generated value</returns>
        double First();

        /// <summary>
        /// Generates the next value in the time series
        /// </summary>
        /// <param name="previous"> previous value</param>
        /// <returns>Generated value</returns>
        double Next(double previous);
    }
}