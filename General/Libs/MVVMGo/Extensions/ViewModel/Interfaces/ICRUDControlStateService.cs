using System.Collections.Generic;
using AddOns.ControlState.Interfaces;

namespace Extensions.ViewModel.Interfaces
{
    /// <summary>
    /// Interface for adding control state definitions "in bulk", 
    /// if a View mainly has default behaviors for its controls.
    /// </summary>
    public interface ICRUDControlStateService : IControlStateService
    {
        /// <summary>
        /// Specifies controls that will never 
        /// be enabled after object creation.
        /// </summary>
        /// <param name="ids">List of control identifiers</param>
        void AddImmutableControlsDefaultStates(List<string> ids);

        /// <summary>
        /// Specifies controls that may be 
        /// enabled after object creation.
        /// </summary>
        /// <param name="ids">List of control identifiers</param>
        void AddMutableControlsDefaultStates(List<string> ids);

        /// <summary>
        /// Sets default dehavior for controls 
        /// used for invoking CRUD operations.
        /// This could e.g. be Button controls.
        /// </summary>
        void AddCRUDInvokerDefaultStates();

        /// <summary>
        /// Sets default dehavior for controls 
        /// used for selecting CRUD view states.
        /// This could e.g. be RadioButton controls.
        /// </summary>
        void AddStateSelectorDefaultStates();

        /// <summary>
        /// Sets default dehavior for control 
        /// used for selecting an item.
        /// This could e.g. be ListView control.
        /// </summary>
        void AddItemSelectorDefaultStates();
    }
}