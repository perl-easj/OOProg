using System;
using PvPSimulator.Config;
using PvPSimulator.Players;
using PvPSimulator.Tactics;
using PvPSimulator.Utility;

namespace PvPSimulator.Model
{
    /// <summary>
    /// This class maintains a model of a PvP game. 
    /// A PvP game is a battle between two players 
    /// (player A and B). Each player is allowed to 
    /// change tactics once during a battle.
    /// </summary>
    public class BattleModel
    {
        public enum PlayerID { A, B }

        #region Instance fields
        private IPlayer _playerA;
        private IPlayer _playerB;

        private TacticsData _tacticsData;
        private bool _tacticsLockedA;
        private bool _tacticsLockedB;
        private bool _turn;
        #endregion

        #region Constructor
        public BattleModel()
        {
            _tacticsData = new TacticsData();
            Reset();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Returns whether or not the current game is over, 
        /// defined as at least one of the players being dead.
        /// </summary>
        public bool GameOver
        {
            get { return _playerA.IsDead || _playerB.IsDead; }
        }

        /// <summary>
        /// Returns the tactic designated as the "default" tactic
        /// </summary>
        public ITacticsInfo DefaultTacticsInfo
        {
            get { return _tacticsData.GeTacticsInfo(TacticsType.Offensive); }
        }

        /// <summary>
        /// Returns the tactic designated as the "alternative" tactic
        /// </summary>
        public ITacticsInfo AlternativeTacticsInfo
        {
            get { return _tacticsData.GeTacticsInfo(TacticsType.Defensive); }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Given a player ID, return the corresponding player object.
        /// </summary>
        public IPlayer GetPlayer(PlayerID id)
        {
            return id == PlayerID.A ? _playerA : _playerB;
        }

        /// <summary>
        /// Given a player ID, return the tactics lock state 
        /// for the corresponding player.
        /// </summary>
        public bool GetTacticsLockedState(PlayerID id)
        {
            return id == PlayerID.A ? _tacticsLockedA : _tacticsLockedB;
        }

        /// <summary>
        /// Given a player ID, return whether or not the
        /// player is up for a turn.
        /// </summary>
        public bool PlayerTurn(PlayerID id)
        {
            return id == PlayerID.A ? _turn : !_turn;
        }

        /// <summary>
        /// Let the player defined by the given player ID perform
        /// the player action, i.e. deal damage to the opponent.
        /// </summary>
        public void PlayerAct(PlayerID id)
        {
            if (id == PlayerID.A)
            {
                _playerB.ReceiveDamage(_playerA.DealDamage());
            }
            else
            {
                _playerA.ReceiveDamage(_playerB.DealDamage());
            }
            _turn = !_turn; // Toggle player turn
            OnBattleModelChanged();
        }

        /// <summary>
        /// Change the tactics setting for the player defined by the
        /// player ID, if the player has not changed tactics before.
        /// </summary>
        public void SetPlayerTactics(PlayerID id, ITacticsInfo tactics)
        {
            if (id == PlayerID.A && !_tacticsLockedA)
            {
                _playerA.CurrentTactics = tactics;
                _tacticsLockedA = true;
            }
            if (id == PlayerID.B && !_tacticsLockedB)
            {
                _playerB.CurrentTactics = tactics;
                _tacticsLockedB = true;
            }
            OnBattleModelChanged();
        }

        /// <summary>
        /// Reset entire game
        /// </summary>
        public void Reset()
        {
            _playerA = GameConfiguration.Instance.Factory.CreatePlayerA();
            _playerB = GameConfiguration.Instance.Factory.CreatePlayerB();

            _playerA.CurrentTactics = _tacticsData.GeTacticsInfo(TacticsType.Offensive);
            _playerB.CurrentTactics = _tacticsData.GeTacticsInfo(TacticsType.Offensive);

            _tacticsLockedA = false;
            _tacticsLockedB = false;
            _turn = true;

            BattleLog.Instance.Reset();

            OnBattleModelChanged();
        } 
        #endregion

        #region Events
        /// <summary>
        /// Anyone interested in being informed about changes
        /// in the battle model can register at this event.
        /// </summary>
        public event Action BattleModelChanged;
        protected virtual void OnBattleModelChanged()
        {
            BattleModelChanged?.Invoke();
        } 
        #endregion
    }
}