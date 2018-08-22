using Windows.UI.Xaml;
using AddOns.ControlState.Interfaces;

namespace AddOns.ControlState.Implementation
{
    /// <summary>
    /// Implementation of IControlState interface. Contains a number of
    /// constructors for easy definition of typical control states.
    /// </summary>
    public class GUIControlState : IControlState
    {
        #region Default states for control types
        public const ControlStateType ListViewStateDefault = ControlStateType.Enabled;
        public const ControlStateType PropertyStateDefault = ControlStateType.Enabled;
        public const ControlStateType ButtonStateDefault = ControlStateType.Enabled;
        public static bool DefaultEnabled = ControlStateToEnabled(PropertyStateDefault);
        public static Visibility DefaultVisible = ControlStateToVisibility(PropertyStateDefault);
        #endregion

        #region Instance fields
        private string _id;
        private string _description;
        private bool _enabled;
        private Visibility _visibilityState;
        #endregion

        #region Public properties
        public string ID
        {
            get { return _id; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }

        public Visibility VisibilityState
        {
            get { return _visibilityState; }
            set { _visibilityState = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Description same as id, use default states.
        /// </summary>
        public GUIControlState(string id)
            : this(id, id)
        {
        }

        /// <summary>
        /// Use default states.
        /// </summary>
        public GUIControlState(string id, string description)
            : this(id, description, DefaultEnabled, DefaultVisible)
        {
        }

        /// <summary>
        /// Description same as id, use default visibility.
        /// </summary>
        public GUIControlState(string id, bool enabled)
            : this(id, id, enabled, DefaultVisible)
        {
        }

        /// <summary>
        /// Description same as id.
        /// </summary>
        public GUIControlState(string id, bool enabled, Visibility visibilityState)
            : this(id, id, enabled, visibilityState)
        {
        }

        /// <summary>
        /// Explicit specification of all properties.
        /// </summary>
        public GUIControlState(string id, string description, bool enabled, bool visible)
            : this(id, description, enabled, VisibleToVisibility(visible))
        {
        }

        /// <summary>
        /// Full constructor.
        /// </summary>
        private GUIControlState(string id, string description, bool enabled, Visibility visibilityState)
        {
            _id = id;
            _description = description;
            _enabled = enabled;
            _visibilityState = visibilityState;
        }
        #endregion

        #region Converters
        public static bool ControlStateToEnabled(ControlStateType state)
        {
            return (state == ControlStateType.Enabled);
        }

        public static bool VisibilityToVisible(Visibility state)
        {
            return (state == Visibility.Visible);
        }

        public static Visibility VisibleToVisibility(bool visible)
        {
            return (visible ? Visibility.Visible : Visibility.Collapsed);
        }

        public static Visibility ControlStateToVisibility(ControlStateType state)
        {
            if (state == ControlStateType.Collapsed)
            {
                return Visibility.Collapsed;
            }

            return Visibility.Visible;
        }
        #endregion
    }
}