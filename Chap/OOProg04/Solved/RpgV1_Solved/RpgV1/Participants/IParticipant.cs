using System.Collections.Generic;
using RpgV1.Spells;

namespace RpgV1.Participants
{
    /// <summary>
    /// Interface for all participants in the game world.
    /// </summary>
    public interface IParticipant 
    {
        /// <summary>
        /// All participants have a name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// All Participants have a Level (from 1 and up)
        /// </summary>
        int Level { get; }

        /// <summary>
        /// All participants have a Modifier, but its value is interpreted
        /// differently in Player and Opponent (see classes for more details).
        /// </summary>
        double Modifier { get; }

        /// <summary>
        /// All participants have a SpellVector, but its content is interpreted
        /// differently in Player and Opponent (see classes for more details).
        /// </summary>
        Dictionary<SpellType, double> SpellVector { get; }

        /// <summary>
        /// All participants have a NotPresentValue, which represents the "default" value
        /// corresponding to a spell type, if no entry for that Spell type in found in the
        /// SpellVector. The specific value is set in the derived classes.
        /// </summary>
        double NotPresentValue { get; }
    }
}