using SlicesOfPiUI.ViewModels;

namespace SlicesOfPiUI.Commands
{
    /// <summary>
    /// Command class for starting a calculation
    /// </summary>
    public class StartCalcCmd : CommandBase
    {
        private CalcViewModelBase _viewModel;

        public StartCalcCmd(CalcViewModelBase viewModel)
        {
            _viewModel = viewModel;
        }

        protected override bool CanExecute()
        {
            return !_viewModel.CalcIsRunning;
        }

        protected override void Execute()
        {
            _viewModel.StartCalc();
        }
    }
}