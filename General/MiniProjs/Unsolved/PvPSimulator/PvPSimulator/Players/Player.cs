using PvPSimulator.Tactics;
using PvPSimulator.Utility;

namespace PvPSimulator.Players
{
    /// <summary>
    /// Base class for player. Dynamic information about the player is
    /// held directly in the Player objects, while constant information 
    /// is held in a PlayerInfo object. 
    /// </summary>
    public class Player : IPlayer
    {
        #region Instance fields
        protected IPlayerInfo Info;
        private ITacticsInfo _tactics;
        private double _currentHitpoints;
        #endregion

        #region Constructor
        public Player(string name, string type, int initialHitPoints, double baseDamage, ITacticsInfo tactics)
        {
            Info = new PlayerInfo(name, type, initialHitPoints, baseDamage);
            _tactics = tactics;
            Reset();
        }
        #endregion

        #region Properties
        public string Name
        {
            get { return Info.Name; }
        }

        public string Type
        {
            get { return Info.Type; }
        }

        public double CurrentHitPoints
        {
            get { return _currentHitpoints; }
        }

        public double InitialHitPoints
        {
            get { return Info.InitialHitPoints; }
        }

        public double AttackFactor
        {
            get { return _tactics.AttackFactor; }
        }

        public double DefenseFactor
        {
            get { return _tactics.DefenseFactor; }
        }

        public TacticsType CurrentTacticsType
        {
            get { return _tactics.Type; }
        }

        public ITacticsInfo CurrentTactics
        {
            get { return _tactics; }
            set { _tactics = value; }
        }

        public bool IsDead
        {
            get { return _currentHitpoints <= 0; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Inflicts the specified amount of damage on the player.
        /// This damage may be modified by the defense factor.
        /// </summary>
        public void ReceiveDamage(double damagePoints)
        {
            // Calculate and deduct net received damage
            double netDamagePoints = damagePoints / _tactics.DefenseFactor;
            _currentHitpoints = _currentHitpoints - netDamagePoints;

            // Update battle log
            BattleLog.Instance.Save($"{Name} received {netDamagePoints:F1} damage (mitigated), and is down to {_currentHitpoints:F1} HP");
            if (IsDead)
            {
                BattleLog.Instance.Save($"{Name} died...");
            }
        }

        /// <summary>
        /// Deals the returned amount of damage. 
        /// This damage may be modified by the attack factor.
        /// </summary>
        public double DealDamage()
        {
            // Calculate net damage dealt, and update battle log.
            double netDamage = NumberGenerator.Instance.Next(1, Info.BaseDamage) * _tactics.AttackFactor;
            BattleLog.Instance.Save($"{Name} dealt {netDamage:F1} damage");

            return netDamage;
        }

        /// <summary>
        /// Resets the player back to its initial state.
        /// </summary>
        public void Reset()
        {
            _currentHitpoints = Info.InitialHitPoints;
        } 
        #endregion
    }
}