using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PvPSimulator.Commands;
using PvPSimulator.Model;
using PvPSimulator.Players;
using PvPSimulator.Tactics;
using PvPSimulator.Utility;

namespace PvPSimulator.ViewModel
{
    /// <summary>
    /// View model for a PvP battle, used for Data Binding in a view. 
    /// The view model refers to a single BattleModel object.
    /// Note that the view model creates the BattleModel object.
    /// </summary>
    public class BattleViewModel : INotifyPropertyChanged
    {
        #region Constants
        public const string PlayerAID = "PlayerA";
        public const string PlayerBID = "PlayerB";

        public const string PlayerAAttackControlID = "AttackPlayerA";
        public const string PlayerBAttackControlID = "AttackPlayerB";
        public const string ResetControlID = "Reset";

        public const string PlayerATacticsControlID = "PlayerATactics";
        public const string PlayerBTacticsControlID = "PlayerBTactics"; 
        #endregion

        #region Instance fields
        private Dictionary<string, CommandBase> _commands;
        private BattleModel _model;
        #endregion

        #region Constructor
        public BattleViewModel()
        {
            // Create BattleModel object, and set up handler to
            // react to subsequent changes in BattleModel object.
            _model = new BattleModel();
            _model.BattleModelChanged += BattleModelChangedHandler;

            // Initialise Command dictionary with commands
            // for player attacks and game reset.
            _commands = new Dictionary<string, CommandBase>();
            _commands.Add(PlayerAAttackControlID, new AttackCommand(_model, BattleModel.PlayerID.A));
            _commands.Add(PlayerBAttackControlID, new AttackCommand(_model, BattleModel.PlayerID.B));
            _commands.Add(ResetControlID, new ResetCommand(_model));
        }
        #endregion

        #region Public properties used for Data Binding
        /// <summary>
        /// Returns entire Dictionary of command objects.
        /// Used for Data Binding in view.
        /// </summary>
        public Dictionary<string, CommandBase> Commands
        {
            get { return _commands; }
        }

        /// <summary>
        /// Returns Dictionary of enabled states for controls in view.
        /// A control is referenced by a string identifier.
        /// </summary>
        public Dictionary<string, bool> EnabledState
        {
            get
            {
                // Add enabled states for Attack and Reset controls
                Dictionary<string, bool> enabled = new Dictionary<string, bool>();
                foreach (var kvp in _commands)
                {
                    enabled.Add(kvp.Key, kvp.Value.CanExecute(null));
                }

                // Add enabled states for Tactics controls
                enabled.Add(PlayerATacticsControlID, !_model.GetTacticsLockedState(BattleModel.PlayerID.A) && !_model.GameOver);
                enabled.Add(PlayerBTacticsControlID, !_model.GetTacticsLockedState(BattleModel.PlayerID.B) && !_model.GameOver);

                return enabled;
            }
        }

        /// <summary>
        /// Returns a Dictionary of PlayerViewModel objects.
        /// Used for Data Binding in view.
        /// </summary>
        public Dictionary<string, PlayerViewModel> PlayerInfo
        {
            get
            {
                Dictionary<string, PlayerViewModel> info = new Dictionary<string, PlayerViewModel>();
                info.Add(PlayerAID, new PlayerViewModel(PlayerA));
                info.Add(PlayerBID, new PlayerViewModel(PlayerB));

                return info;
            }
        }

        /// <summary>
        /// Returns a (reversed) ObservableCollection  
        /// of all strings in the battle log.
        /// </summary>
        public ObservableCollection<string> LogEntries
        {
            get
            {
                ObservableCollection<string> entries = new ObservableCollection<string>();
                for (int i = BattleLog.Instance.Content.Count - 1; i >= 0; i--)
                {
                    entries.Add(BattleLog.Instance.Content[i]);
                }

                return entries;
            }
        }

        /// <summary>
        /// Get/set current tactics for Player A. Current mapping is:
        /// true = Default tactics
        /// false = Alternative tactics
        /// </summary>
        public bool TacticsSettingPlayerA
        {
            get { return PlayerA.CurrentTacticsType == _model.DefaultTacticsInfo.Type; }
            set
            {
                ITacticsInfo tactics = value ? _model.DefaultTacticsInfo : _model.AlternativeTacticsInfo;
                _model.SetPlayerTactics(BattleModel.PlayerID.A, tactics);
            }
        }

        /// <summary>
        /// Get/set current tactics for Player B. Current mapping is:
        /// true = Default tactics
        /// false = Alternative tactics
        /// </summary>
        public bool TacticsSettingPlayerB
        {
            get { return PlayerB.CurrentTacticsType == _model.DefaultTacticsInfo.Type; }
            set
            {
                ITacticsInfo tactics = value ? _model.DefaultTacticsInfo : _model.AlternativeTacticsInfo;
                _model.SetPlayerTactics(BattleModel.PlayerID.B, tactics);
            }
        }
        #endregion

        #region Private properties
        /// <summary>
        /// Gets Player A from model (just a convenient shorthand).
        /// </summary>
        private IPlayer PlayerA
        {
            get { return _model.GetPlayer(BattleModel.PlayerID.A); }
        }

        /// <summary>
        /// Gets Player B from model (just a convenient shorthand).
        /// </summary>
        private IPlayer PlayerB
        {
            get { return _model.GetPlayer(BattleModel.PlayerID.B); }
        } 
        #endregion

        #region Methods
        /// <summary>
        /// Handler for changes in underlying BattleModel object.
        /// Invokes OnPropertyChanged on all relevant properties,
        /// and RaiseCanExecuteChanged on all command objects.
        /// </summary>
        private void BattleModelChangedHandler()
        {
            OnPropertyChanged(nameof(EnabledState));
            OnPropertyChanged(nameof(PlayerInfo));
            OnPropertyChanged(nameof(LogEntries));
            foreach (var command in _commands.Values)
            {
                command.RaiseCanExecuteChanged();
            }
        } 
        #endregion

        #region OnPropertyChanged code
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
    }
}