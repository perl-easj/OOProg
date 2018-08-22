using System;
using System.Collections.Generic;
using AddOns.ControlState.Interfaces;

namespace AddOns.ControlState.Implementation
{
    /// <summary>
    /// Implementation of the IControlStateService interface. 
    /// The implementation does not make any assumptions 
    /// about specific controls or view states.
    /// </summary>
    public class ControlStateService : IControlStateService
    {
        #region Instance fields
        private Dictionary<string, Dictionary<string, IControlState>> _controlStateMap;
        private List<string> _controlIDs;
        private List<string> _validStates;
        #endregion

        #region Constructor
        public ControlStateService(List<string> validStates)
        {
            // Sanity check
            if (validStates == null || validStates.Count == 0)
            {
                throw new ArgumentException(nameof(ControlStateService));
            }

            _validStates = validStates;
            _controlIDs = new List<string>();
            _controlStateMap = new Dictionary<string, Dictionary<string, IControlState>>();

            foreach (string viewState in _validStates)
            {
                _controlStateMap.Add(viewState, new Dictionary<string, IControlState>());
            }
        }
        #endregion

        /// <inheritdoc />
        /// <summary>
        /// Returns Dictionary of all control states corresponding
        /// to the given view state. An exception is thrown if the
        /// given view state is unknown.
        /// </summary>
        /// <param name="state">
        /// View state
        /// </param>
        public Dictionary<string, IControlState> GetControlStates(string state)
        {
            // Sanity check
            if (!_controlStateMap.ContainsKey(state))
            {
                throw new ArgumentException(nameof(GetControlStates));
            }

            return _controlStateMap[state];
        }

        /// <inheritdoc />
        /// <summary>
        /// Adds a new control state, assumed to apply to all valid view states.
        /// </summary>
        /// <param name="controlState">
        /// Control state definition object.
        /// </param>
        public void AddControlState(IControlState controlState)
        {
            foreach (string viewState in _validStates)
            {
                AddControlState(viewState, controlState);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Adds a new control state, assumed to apply only to the given view state.
        /// </summary>
        /// <param name="state">
        /// View state
        /// </param>
        /// <param name="controlState">
        /// Control state definition object.
        /// </param>
        public void AddControlState(string state, IControlState controlState)
        {
            // Add name, if not seen before
            if (!_controlIDs.Contains(controlState.ID))
            {
                _controlIDs.Add(controlState.ID);
            }

            _controlStateMap[state][controlState.ID] = controlState;
        }
    }
}