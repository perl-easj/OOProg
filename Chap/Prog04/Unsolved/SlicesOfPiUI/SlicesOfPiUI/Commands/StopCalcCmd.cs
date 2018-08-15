using SlicesOfPiUI.ViewModels;

namespace SlicesOfPiUI.Commands
{
    /// <summary>
    /// Command class for stopping a calculation
    /// </summary>
    public class StopCalcCmd : CommandBase
    {
        private CalcViewModelBase _viewModel;

        public StopCalcCmd(CalcViewModelBase viewModel)
        {
            _viewModel = viewModel;
        }

        protected override bool CanExecute()
        {
            return _viewModel.CalcIsRunning;
        }

        protected override void Execute()
        {
            _viewModel.StopCalc();
        }
    }
}