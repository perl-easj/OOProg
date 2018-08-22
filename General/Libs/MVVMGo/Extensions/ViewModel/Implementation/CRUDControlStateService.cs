using System.Collections.Generic;
using Windows.UI.Xaml;
using AddOns.ControlState.Implementation;
using AddOns.ControlState.Interfaces;
using Extensions.Commands.Interfaces;
using Extensions.ViewModel.Interfaces;

namespace Extensions.ViewModel.Implementation
{
    /// <summary>
    /// This class implements methods specific for 
    /// managing control states in a CRUD-oriented view.
    /// That is, the view has states and controls 
    /// corresponding to CRUD operations, and contains 
    /// sets of controls with identical behavior.
    /// </summary>
    public class CRUDControlStateService : ControlStateService, ICRUDControlStateService
    {
        public CRUDControlStateService()
            : base(new List<string> { CRUDStates.CreateState, CRUDStates.ReadState, CRUDStates.UpdateState, CRUDStates.DeleteState })
        {
        }

        /// <summary>
        /// Specifies controls that will never 
        /// be enabled after object creation.
        /// </summary>
        /// <param name="ids">List of control identifiers</param>
        public void AddImmutableControlsDefaultStates(List<string> ids)
        {
            AddControlDefaultStatesMultiple(ids, MutableType.Immutable);
        }

        /// <summary>
        /// Specifies controls that may 
        /// be enabled after object creation.
        /// </summary>
        /// <param name="ids">List of control identifiers</param>
        public void AddMutableControlsDefaultStates(List<string> ids)
        {
            AddControlDefaultStatesMultiple(ids, MutableType.Mutable);
        }

        /// <summary>
        /// Sets default dehavior for controls used for 
        /// invoking CRUD operations. This could e.g. be 
        /// Button controls. In this implementation, the 
        /// states are set for Create, Update and Delete.
        /// </summary>
        public void AddCRUDInvokerDefaultStates()
        {
            AddControlState(new GUIControlState(CRUDControls.CreateControl));
            AddControlState(new GUIControlState(CRUDControls.UpdateControl));
            AddControlState(new GUIControlState(CRUDControls.DeleteControl));
        }

        /// <summary>
        /// Sets default dehavior for controls used for 
        /// selecting CRUD view states. This could e.g. be 
        /// RadioButton controls.In this implementation, 
        /// the states are set for all CRUD operations.
        /// </summary>
        public void AddStateSelectorDefaultStates()
        {
            AddControlState(new GUIControlState(CRUDStateControls.CreateStateControl));
            AddControlState(new GUIControlState(CRUDStateControls.ReadStateControl));
            AddControlState(new GUIControlState(CRUDStateControls.UpdateStateControl));
            AddControlState(new GUIControlState(CRUDStateControls.DeleteStateControl));
        }

        /// <summary>
        /// Sets default dehavior for a control used for 
        /// selecting an item. This could e.g. be a ListView 
        /// control. In this implementation, the selector 
        /// control is visible in all states except Create state.
        /// </summary>
        public void AddItemSelectorDefaultStates()
        {
            AddControlState(CRUDStates.CreateState, new GUIControlState(CRUDControls.ItemSelectorControl, false, Visibility.Collapsed));
            AddControlState(CRUDStates.ReadState, new GUIControlState(CRUDControls.ItemSelectorControl, true, Visibility.Visible));
            AddControlState(CRUDStates.UpdateState, new GUIControlState(CRUDControls.ItemSelectorControl, true, Visibility.Visible));
            AddControlState(CRUDStates.DeleteState, new GUIControlState(CRUDControls.ItemSelectorControl, true, Visibility.Visible));
        }

        /// <summary>
        /// Adds the default control states for a set of controls.
        /// </summary>
        /// <param name="ids">
        /// List of control identifiers
        /// </param>
        /// <param name="mutable">
        /// Mutability of controls. Applies to all controls in list.
        /// </param>
        private void AddControlDefaultStatesMultiple(List<string> ids, MutableType mutable)
        {
            foreach (string id in ids)
            {
                AddControlDefaultStates(id, mutable);
            }
        }

        /// <summary>
        /// Adds the default control states for a control. 
        /// In this implementation, the default control states are:
        /// Create state: Control is enabled.
        /// Read state: Control is disabled.
        /// Update state: Control state as specific by "mutable" parameter
        /// Delete state: Control is disabled.
        /// </summary>
        /// <param name="id">
        /// Control identifier
        /// </param>
        /// <param name="mutable">
        /// Mutability of control.
        /// </param>
        private void AddControlDefaultStates(string id, MutableType mutable)
        {
            AddControlState(CRUDStates.CreateState, new GUIControlState(id, true));
            AddControlState(CRUDStates.ReadState, new GUIControlState(id, false));
            AddControlState(CRUDStates.UpdateState, new GUIControlState(id, mutable == MutableType.Mutable));
            AddControlState(CRUDStates.DeleteState, new GUIControlState(id, false));
        }
    }
}