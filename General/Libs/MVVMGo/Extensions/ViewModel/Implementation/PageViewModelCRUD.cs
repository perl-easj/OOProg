using System.Collections.Generic;
using Data.InMemory.Interfaces;
using Extensions.Commands.Implementation;
using Extensions.Commands.Interfaces;
using Model.Interfaces;

namespace Extensions.ViewModel.Implementation
{
    /// <summary>
    /// This class injects specific dependencies into the PageViewModelWithState class, 
    /// making it a CRUD-specific implementation:
    /// 1) List of immutable controls having default behavior
    /// 2) List of mutable controls having default behavior
    /// 3) Addition of CRUD-specific command managers.
    /// 4) Addition of default control behaviors for CRUD invocation, 
    ///    view state selection and item selection.
    /// 5) Addition of CRUD-specific mediator.
    /// </summary>
    public abstract class PageViewModelCRUD<TViewData> : PageViewModelWithState<TViewData>
        where TViewData : class, ICopyable, IStorable, new()
    {
        private PageViewModelCRUDMediator<TViewData> _mediator;

        protected PageViewModelCRUD(
            ICatalog<TViewData> catalog,
            List<string> immutableControls,
            List<string> mutableControls,
            string initialViewState = CRUDStates.ReadState)
            : base(catalog)
        {
            CRUDControlStateService CRUDcontrolStateService = new CRUDControlStateService();

            SetupControlBehaviors(CRUDcontrolStateService, immutableControls, mutableControls);

            // Set state services to refer to CRUD-specific services
            ViewStateService = new CRUDViewStateService();
            ControlStateService = CRUDcontrolStateService;

            SetupCommandManagers(catalog);
            SetupInitialViewState(initialViewState);

            // Set mediator to a state-aware implementation
            _mediator = new PageViewModelCRUDMediator<TViewData>(this, catalog);
        }

        protected PageViewModelCRUD(ICatalog<TViewData> catalog, string initialViewState = CRUDStates.ReadState)
            : this(catalog, new List<string>(), new List<string>(), initialViewState)
        {
        }

        protected virtual void SetupControlBehaviors(
            CRUDControlStateService stateService,
            List<string> immutableControls, List<string> mutableControls)
        {
            stateService.AddImmutableControlsDefaultStates(immutableControls);
            stateService.AddMutableControlsDefaultStates(mutableControls);
            stateService.AddCRUDInvokerDefaultStates();
            stateService.AddStateSelectorDefaultStates();
            stateService.AddItemSelectorDefaultStates();
        }

        protected virtual void SetupCommandManagers(ICatalog<TViewData> catalog)
        {
            DataCommandManager = new CRUDCommandManagerViewStateDependent<TViewData>(this, catalog, this);
            StateCommandManager = new CRUDViewStateSelectCommandManager(ViewStateService);
        }

        protected virtual void SetupInitialViewState(string initialViewState = CRUDStates.ReadState)
        {
            ViewStateService.ViewState = initialViewState;
        }
    }
}