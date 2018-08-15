using PvPSimulator.Tactics;

namespace PvPSimulator.Players
{
    /// <summary>
    /// Interface for a Player, i.e. a participant
    /// in a Player-vs-Player battle simulation.
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// Returns name of player
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Returns type of player (e.g. Warrior, Wizard, etc.)
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Returns the initial hit points for the player
        /// </summary>
        double InitialHitPoints { get; }

        /// <summary>
        /// Returns the current hit points for the player
        /// </summary>
        double CurrentHitPoints { get; }

        /// <summary>
        /// Returns the attack factor for the player.
        /// Whenever a players attacks, the base damage
        /// dealt is multiplied with the attack factor.
        /// </summary>
        double AttackFactor { get; }

        /// <summary>
        /// Returns the defense factor for the player.
        /// Whenever a players is attacked, the base 
        /// damage received is divided with by the 
        /// defense factor.
        /// </summary>
        double DefenseFactor { get; }

        /// <summary>
        /// Returns the current tactics type used by the player.
        /// </summary>
        TacticsType CurrentTacticsType { get; }

        /// <summary>
        /// Get/set the current tactics used by the player.
        /// </summary>
        ITacticsInfo CurrentTactics { get; set; }

        /// <summary>
        /// Returns whether or not the player is currently dead.
        /// </summary>
        bool IsDead { get; }

        /// <summary>
        /// Inflicts the specified amount of damage on the player.
        /// This damage may be modified by the defense factor.
        /// </summary>
        void ReceiveDamage(double damagePoints);

        /// <summary>
        /// Deals the returned amount of damage. 
        /// This damage may be modified by the attack factor.
        /// </summary>
        double DealDamage();

        /// <summary>
        /// Resets the player back to its initial state.
        /// </summary>
        void Reset();
    }
}