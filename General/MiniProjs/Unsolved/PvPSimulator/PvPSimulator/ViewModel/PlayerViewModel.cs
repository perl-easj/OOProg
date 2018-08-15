using Windows.UI;
using Windows.UI.Xaml.Media;
using PvPSimulator.Players;

namespace PvPSimulator.ViewModel
{
    /// <summary>
    /// View model for player information, used for Data Binding in
    /// a view. The view model refers to a single IPlayer object.
    /// Note that the class does not implement INotifyPropertyChanged,
    /// since all of its properties are read-only.
    /// </summary>
    public class PlayerViewModel
    {
        #region Instance fields
        private IPlayer _player;
        #endregion

        #region Constructor
        public PlayerViewModel(IPlayer player)
        {
            _player = player;
        }
        #endregion

        #region Public properties used for Data Binding
        /// <summary>
        /// Returns the name of the player
        /// </summary>
        public string Name
        {
            get { return _player.Name; }
        }

        /// <summary>
        /// Returns the type of the player
        /// (e.g. Warrior, Wizard, etc.)
        /// </summary>
        public string Type
        {
            get { return _player.Type; }
        }

        /// <summary>
        /// Returns the image source of the player. A single 
        /// image is used for all players of a specific type.
        /// </summary>
        public string ImageSource
        {
            get { return $"../Assets/{_player.Type}.jpg"; }
        }

        /// <summary>
        /// Returns a string representation of the current hit points for the player.
        /// Note that DEAD is returned in case the player is actually dead. 
        /// </summary>
        public string HitPoints
        {
            get { return _player.IsDead ? "DEAD" : $"{_player.CurrentHitPoints:F2}"; }
        }

        /// <summary>
        /// Returns a color to be used when displaying hit points on screen.
        /// The color reflects the current health of the player.
        /// </summary>
        public SolidColorBrush HitPointsColor
        {
            get
            {
                double percent = (100.0 * _player.CurrentHitPoints) / _player.InitialHitPoints;
                return new SolidColorBrush(PercentToColor(percent));
            }
        }

        /// <summary>
        /// Returns a string representation of the current attack factor for the player.
        /// </summary>
        public string AttackFactor
        {
            get { return $"{_player.AttackFactor:F2}"; }
        }

        /// <summary>
        /// Returns a string representation of the current attack factor for the player.
        /// </summary>
        public string DefenseFactor
        {
            get { return $"{_player.DefenseFactor:F2}"; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Converts the current health of the player 
        /// (measured as the percentage of hit points left), 
        /// to a color, which can utilised in a view.
        /// </summary>
        private Color PercentToColor(double percent)
        {
            if (percent > 50) // Good health
            {
                return Colors.Green;
            }
            else if (percent > 25)  // Poor health
            {
                return Colors.Orange;
            }
            else if (percent > 0) // Critical health
            {
                return Colors.OrangeRed;
            }

            return Colors.Red;  // Dead
        } 
        #endregion
    }
}