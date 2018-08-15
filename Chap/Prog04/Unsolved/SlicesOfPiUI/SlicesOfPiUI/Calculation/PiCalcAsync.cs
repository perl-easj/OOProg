using System;
using System.Threading;
using System.Threading.Tasks;

namespace SlicesOfPiUI.Calculation
{
    /// <summary>
    /// This class contains the asynchronous version
    /// of the calculation algorithm.
    /// </summary>
    public class PiCalcAsync : PiCalcBase
    {
        public PiCalcAsync(IProgress<long> progressCallback) 
            : base(progressCallback)
        {
        }

        /// <summary>
        /// Calculates an approximate value of Pi.
        /// Note that this version of the algorithm is async.
        /// </summary>
        public async Task CalculateAsync(PiCalcData data, CancellationToken token)
        {
            // Main loop in algorithm (started as a new Task, is cancellable).
            //
            await Task.Run(() => Calculate(data, () => !token.IsCancellationRequested), token);
        }
    }
}