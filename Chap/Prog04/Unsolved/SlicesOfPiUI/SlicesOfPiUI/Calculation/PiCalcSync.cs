using System;

namespace SlicesOfPiUI.Calculation
{
    /// <summary>
    /// This class contains the synchronous version
    /// of the calculation algorithm.
    /// </summary>
    public class PiCalcSync : PiCalcBase
    {
        public PiCalcSync(IProgress<long> progressCallback)
            : base(progressCallback)
        {
        }

        /// <summary>
        /// Calculates an approximate value of Pi.
        /// Note that this version does NOT use async.
        /// </summary>
        public double CalculateSync(long iterationsRequested)
        {
            _iterationsRequested = iterationsRequested;

            return Calculate();
        }

        /// <summary>
        /// In this case, the calculation stops when the requested
        /// number of iterations have been performed. 
        /// </summary>
        protected override bool StopCondition()
        {
            return _iterationsDone >= _iterationsRequested;
        }
    }
}