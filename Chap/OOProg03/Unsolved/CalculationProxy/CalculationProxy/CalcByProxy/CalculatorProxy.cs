using CalculationProxy.Common;

namespace CalculationProxy.CalcByProxy
{
    /// <summary>
    /// Class which acts as a proxy for a real calculation class.
    /// </summary>
    public class CalculatorProxy : ICalculate
    {
        #region Instance fields
        private Cache _cache;
        private ICalculate _calculator;
        #endregion

        #region Constructor
        public CalculatorProxy()
        {
            _cache = new Cache();
            _calculator = CalculatorFactory.Create(false);
        }
        #endregion

        #region Methods
        /// <summary>
        /// The proxy should implement the Calculate method by this strategy:
        /// 1) Given the Coordinate c, try to look up a result in the Cache,
        ///    by using the _cache instance field.
        /// 2) If a result was found in the cache, return it immediately to the caller.
        /// 3) If a result was NOT found in the cache, then
        ///    3a) Calculate the result, using the _calculator instance field.
        ///    3b) Store the returned result in the cache.
        ///    3c) Return the calculated result to the caller.
        /// </summary>
        public int Calculate(Coordinate c)
        {
            // Implement this method according to the description above.
            return _calculator.Calculate(c);
        } 
        #endregion
    }
}