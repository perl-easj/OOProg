using SimpleRPGFromScratch.Command.Base;
using SimpleRPGFromScratch.ViewModel.Base;

namespace SimpleRPGFromScratch.Command.App
{
    /// <summary>
    /// Denne Command-klasse implementerer skift af tilstand i et View.
    /// </summary>
    /// <typeparam name="TDataViewModel"></typeparam>
    public class SetViewStateCommand<TDataViewModel> : CommandBase
    {
        private IPageViewModel<TDataViewModel> _pageViewModel;
        private PageViewModelState _state;

        public SetViewStateCommand(IPageViewModel<TDataViewModel> pageViewModel, PageViewModelState state)
        {
            _pageViewModel = pageViewModel;
            _state = state;
        }

        protected override void Execute()
        {
            _pageViewModel.SetState(_state);
        }
    }
}