using System;
using SlicesOfPiUI.Calculation;

namespace SlicesOfPiUI.ViewModels
{
    /// <summary>
    /// View model for the synchronous version
    /// of the calculation algorithm
    /// </summary>
    public class CalcSyncViewModel : CalcViewModelBase
    {
        public override void StartCalc()
        {
            base.StartCalc();

            PiCalcSync calcSync = new PiCalcSync(CreateProgressObject());
            _piCalculated = calcSync.CalculateSync(IterationsRequested);

            StopCalc();
        }
    }
}