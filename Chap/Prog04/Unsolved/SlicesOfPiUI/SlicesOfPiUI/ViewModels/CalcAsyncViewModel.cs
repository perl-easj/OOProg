using System;
using System.Threading;
using System.Threading.Tasks;
using SlicesOfPiUI.Calculation;

namespace SlicesOfPiUI.ViewModels
{
    /// <summary>
    /// View model for the asynchronous version
    /// of the calculation algorithm
    /// </summary>
    public class CalcAsyncViewModel : CalcViewModelBase
    {
        private CancellationTokenSource _cancellationTokenSource;

        public override async void StartCalc()
        {
            base.StartCalc();
            _cancellationTokenSource = new CancellationTokenSource();

            PiCalcAsync calcAsync = new PiCalcAsync(CreateProgressObject());
            Task<double> calcTask = calcAsync.CalculateAsync(IterationsRequested, _cancellationTokenSource.Token);
            _piCalculated = await calcTask;

            base.StopCalc();
        }

        public override void StopCalc()
        {
            _cancellationTokenSource.Cancel();

            base.StopCalc();
        }
    }
}