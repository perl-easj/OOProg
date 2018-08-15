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
        public void CalculateSync(PiCalcData data, int iterationsToPerform)
        {
            // Main loop in algorithm
            //
            Calculate(data, () => _iterations < iterationsToPerform);
        }
    }
}