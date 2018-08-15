namespace PvPSimulator.Tactics
{
    /// <summary>
    /// Defines an interface for a "battle tactic".
    /// A tactic is specified by a type enumeration, and
    /// corresponding values of attack and defence factors.
    /// </summary>
    public interface ITacticsInfo
    {
        /// <summary>
        /// Returns the type of the tactic.
        /// </summary>
        TacticsType Type { get; }

        /// <summary>
        /// Returns the attack factor for a specific tactic.
        /// </summary>
        double AttackFactor { get; }

        /// <summary>
        /// Returns the defense factor for a specific tactic.
        /// </summary>
        double DefenseFactor { get; }
    }
}