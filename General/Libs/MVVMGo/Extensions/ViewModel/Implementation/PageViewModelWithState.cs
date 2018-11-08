using System.Collections.Generic;
using AddOns.ControlState.Interfaces;
using AddOns.ViewState.Interfaces;
using Commands.Interfaces;
using Data.InMemory.Interfaces;
using Model.Interfaces;
using ViewModel.Page.Implementation;

namespace Extensions.ViewModel.Implementation
{
    /// <summary>
    /// This class adds further properties to the page view model base class:
    /// 1) View state service
    /// 2) Control state service
    /// 3) Data commands (commands for invoking data-related operations)
    /// 4) State commands (commands for setting the view in a specific view state)
    /// Note that the class does not itself choose specific services/commands
    /// </summary>
    public abstract class PageViewModelWithState<TData> : PageViewModelBase<TData>, IHasViewState
        where TData : class, ICopyable, new()
    {
        #region Instance fields
        private IControlStateService _controlStateService;
        private IViewStateService _viewStateService;

        private ICommandManager _dataCommands;
        private ICommandManager _stateCommands;
        #endregion

        #region Constructor
        protected PageViewModelWithState(ICatalog<TData> catalog)
            : base(catalog)
        {
            // These will be initialised in sub-classes,
            // with specific services/commands
            _controlStateService = null;
            _viewStateService = null;
            _dataCommands = null;
            _stateCommands = null;
        }
        #endregion

        #region Exposure of State servies (View and Control)
        public IControlStateService ControlStateService
        {
            get { return _controlStateService; }
            protected set { _controlStateService = value; }
        }

        public IViewStateService ViewStateService
        {
            get { return _viewStateService; }
            protected set { _viewStateService = value; }
        }
        #endregion

        #region Exposure of Command managers (State and Data)
        public ICommandManager DataCommandManager
        {
            get { return _dataCommands; }
            protected set { _dataCommands = value; }
        }

        public ICommandManager StateCommandManager
        {
            get { return _stateCommands; }
            protected set { _stateCommands = value; }
        }
        #endregion

        #region Exposure of Commands (view state selection and data operations)
        public Dictionary<string, INotifiableCommand> StateCommand
        {
            get { return _stateCommands.Commands; }
        }

        public Dictionary<string, INotifiableCommand> DataCommand
        {
            get { return _dataCommands.Commands; }
        }
        #endregion

        #region Exposure of State (view state and control state)
        public Dictionary<string, IControlState> ControlStates
        {
            get { return _controlStateService.GetControlStates(ViewState); }
        }

        public string ViewState
        {
            get { return _viewStateService.ViewState; }
        }

        public string ViewStateDescription
        {
            get { return $"View is in {ViewState.Substring(0, ViewState.Length - 5)} state"; }
        }
        #endregion
    }
}