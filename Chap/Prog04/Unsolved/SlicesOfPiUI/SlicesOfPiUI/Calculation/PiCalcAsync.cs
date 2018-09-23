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
        private CancellationToken _token;

        public PiCalcAsync(IProgress<long> progressCallback) 
            : base(progressCallback)
        {
        }

        /// <summary>
        /// Calculates an approximate value of Pi.
        /// Note that this version of the algorithm is async.
        /// </summary>
        public async Task<double> CalculateAsync(long iterationsRequested, CancellationToken token)
        {
            _iterationsRequested = iterationsRequested;
            _token = token;

            // Wrap the call of Calculate into a Task object,
            // and start the task
            Task<double> calcTask = new Task<double>(Calculate);   
            calcTask.Start();

            // Await the completion of the calculation
            await calcTask;

            // Return the result of the calculation
            return calcTask.Result;
        }

        /// <summary>
        /// In this case, the calculation stops when the requested
        /// number of iterations have been performed, OR a cancellation
        /// request has been issued. 
        /// </summary>
        protected override bool StopCondition()
        {
            return _iterationsDone >= _iterationsRequested || _token.IsCancellationRequested;
        }
    }
}