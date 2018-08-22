using System.Collections.Generic;

namespace AddOns.ControlState.Interfaces
{
    /// <summary>
    /// Interface for any provider of the control state service.
    /// </summary>
    public interface IControlStateService
    {
        /// <summary>
        /// Returns Dictionary of all control states corresponding
        /// to the given view state.
        /// </summary>
        /// <param name="state">
        /// View state
        /// </param>
        Dictionary<string, IControlState> GetControlStates(string state);

        /// <summary>
        /// Adds a new control state, assumed to apply to all valid view states.
        /// </summary>
        /// <param name="controlState">
        /// Control state definition object.
        /// </param>
        void AddControlState(IControlState controlState);

        /// <summary>
        /// Adds a new control state, assumed to apply only to the given view state.
        /// </summary>
        /// <param name="state">
        /// View state
        /// </param>
        /// <param name="controlState">
        /// Control state definition object.
        /// </param>
        void AddControlState(string state, IControlState controlState);
    }
}