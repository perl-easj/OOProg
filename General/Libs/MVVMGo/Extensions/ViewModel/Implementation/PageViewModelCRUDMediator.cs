using AddOns.ViewState.Interfaces;
using Data.InMemory.Interfaces;
using Extensions.Commands.Interfaces;
using Model.Interfaces;
using ViewModel.Page.Implementation;

namespace Extensions.ViewModel.Implementation
{
    /// <summary>
    /// This class implements a specific strategy for mediation between  
    /// elements in a Page with CRUD view state and CRUD operation support.
    /// </summary>
    public class PageViewModelCRUDMediator<TData> : PageViewModelMediatorBase<TData>, IViewStateMediator
        where TData : class, ICopyable, IStorable, new()
    {
        #region Instance fields
        private PageViewModelCRUD<TData> _pageViewModelCRUD;
        #endregion

        #region Constructor
        public PageViewModelCRUDMediator(PageViewModelCRUD<TData> pageViewModelCrud, ICatalog<TData> catalog)
            : base(pageViewModelCrud, catalog)
        {
            _pageViewModelCRUD = pageViewModelCrud;
            _pageViewModelCRUD.ViewStateService.ViewStateChanged += OnViewStateChanged;
        }
        #endregion

        #region Implementation of interface methods
        /// <summary>
        /// Handle changes in view state.
        /// </summary>
        /// <param name="state">
        /// New View State
        /// </param>
        public void OnViewStateChanged(string state)
        {
            // If we are now in the Create state, set selection to null. Otherwise, delegate 
            // the assignment to SetItemDetailsOnItemSelectionChanged directly.
            if (_pageViewModelCRUD.ViewState == CRUDStates.CreateState)
            {
                _pageViewModelCRUD.ItemSelected = null;
            }
            else
            {
                SetItemDetailsOnItemSelectionChanged(_pageViewModelCRUD.ItemSelected?.DataObject);
            }

            // All commands are notified
            NotifyCommands();

            // Control states should be re-read, 
            // since they may depend on view state.
            _pageViewModelCRUD.OnPropertyChanged(nameof(_pageViewModelCRUD.ControlStates));
            _pageViewModelCRUD.OnPropertyChanged(nameof(_pageViewModelCRUD.ViewStateDescription));
        }
        #endregion

        #region Base class overrides
        public override void SetItemDetailsOnItemSelectionChanged(TData vdObjSelected)
        {
            // If new selection is null, we set Details to null as well,
            // except in Create state. In Create state, the selection is
            // set to a new data view model object.
            if (vdObjSelected == null)
            {
                _pageViewModelCRUD.ItemDetails = _pageViewModelCRUD.ViewState == CRUDStates.CreateState ? 
                    _pageViewModelCRUD.CreateDataViewModelFromNewViewData() : 
                    null;
            }
            else
            {
                // For a non-null selection, we set Details to a view model referring to the same view data object,
                // except in Update state. In Update state, Details is set to refer to a clone of the selected
                // view data, in order to be able to update data here through view bindings.
                _pageViewModelCRUD.ItemDetails = (_pageViewModelCRUD.ViewState == CRUDStates.UpdateState) ?
                    _pageViewModelCRUD.CreateDataViewModelFromClonedViewData(vdObjSelected) :
                    _pageViewModelCRUD.CreateDataViewModel(vdObjSelected);
            }
        }

        /// <summary>
        /// All commands are notified, such that the 
        /// CanExecute predicate can be re-evaluated.
        /// </summary>
        public override void NotifyCommands()
        {
            _pageViewModelCRUD.DataCommandManager.Notify();
            _pageViewModelCRUD.StateCommandManager.Notify();
        }
        #endregion
    }
}