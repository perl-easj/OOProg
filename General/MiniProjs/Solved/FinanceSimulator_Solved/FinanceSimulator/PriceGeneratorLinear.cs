namespace FinanceSimulator
{
    /// <summary>
    /// Implementation of IPriceGenerator which generates values linearly.
    /// The generation is done in two steps.
    /// 1) The feasible interval for the next value is determined.
    /// 2) The next value is chosen within this interval, with linear probability.
    /// </summary>
    public class PriceGeneratorLinear : IPriceGenerator
    {
        #region Instance fields
        private double _min;
        private double _max;
        private double _maxChangeRatio;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="min">Minimal valid value</param>
        /// <param name="max">Maximal valid value</param>
        /// <param name="maxChangePercentage">
        /// Maximal change in value when generating the next value,
        /// given in percent.
        /// </param>
        public PriceGeneratorLinear(double min, double max, double maxChangePercentage)
        {
            _min = min;
            _max = max;
            _maxChangeRatio = maxChangePercentage / 100.0;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Generates the first value in the time series
        /// </summary>
        /// <returns>Generated value</returns>
        public double First()
        {
            return (_max + _min) / 2;
        }

        /// <summary>
        /// Generates the next value in the time series
        /// </summary>
        /// <param name="previous"> previous value</param>
        /// <returns>Generated value</returns>
        public double Next(double previous)
        {
            double nextMin = (1 - _maxChangeRatio) * previous;
            double nextMax = (1 + _maxChangeRatio) * previous;

            return RandomNumberGenerator.Next(nextMin, nextMax);
        } 
        #endregion
    }
}