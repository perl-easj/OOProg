namespace PvPSimulator.Players
{
    /// <summary>
    /// Interface defining constant information
    /// about a player, i.e. information which 
    /// does not change over time.
    /// </summary>
    public interface IPlayerInfo
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
        /// Return the base amount of damage dealt by the player. 
        /// This damage may be modified by the attack factor.
        /// </summary>
        double BaseDamage { get; }
    }
}