using Windows.UI.Xaml;

namespace AddOns.ControlState.Interfaces
{
    /// <summary>
    /// Interface for a control state object.
    /// </summary>
    public interface IControlState
    {
        /// <summary>
        /// ID of control to which the control state applies.
        /// The ID can be used as an index when binding GUI control
        /// properties to control state providers.
        /// </summary>
        string ID { get; }

        /// <summary>
        /// Description of control to which the control state applies.
        /// The description can be used as a text label for the GUI
        /// control binding to the control state.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Enabled-state of control to which the control state applies.
        /// </summary>
        bool Enabled { get; set; }

        /// <summary>
        /// Visibility state of control to which the control state applies.
        /// </summary>
        Visibility VisibilityState { get; set; }
    }
}