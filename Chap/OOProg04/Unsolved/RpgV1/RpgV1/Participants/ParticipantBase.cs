using System.Collections.Generic;
using RpgV1.Spells;

namespace RpgV1.Participants
{
    /// <summary>
    /// Base class for all participants in the game world.
    /// </summary>
    public abstract class ParticipantBase : IParticipant
    {
        #region Properties
        public string Name { get; }
        public int Level { get; }
        public Dictionary<SpellType, double> SpellVector { get; }
        public abstract double NotPresentValue { get; }
        public abstract double Modifier { get; }
        #endregion

        #region Constructor
        protected ParticipantBase(string name, int level)
        {
            Name = name;
            Level = level;
            SpellVector = new Dictionary<SpellType, double>();
        }
        #endregion
    }
}