using System.Collections.Generic;

namespace RpgV0.WorldSetup
{
    /// <summary>
    /// Base class for any implementation of a world setup.
    /// </summary>
    public abstract class WorldSetupBase : IWorldSetup
    {
        protected List<Player> Players { get; private set; }
        protected List<Spell> Spells { get; private set; }

        /// <summary>
        /// This method represents the algorithm for world setup, i.e. it's
        /// an example of the Template Method pattern. Note that the specific
        /// steps are represented by abstract methods.
        /// </summary>
        public List<Player> Setup()
        {
            Spells = SetupSpells();
            Players = SetupPlayers(Spells);
            SetupSpellCasting(Players);

            return Players;
        }

        protected abstract List<Spell> SetupSpells();
        protected abstract List<Player> SetupPlayers(List<Spell> spells);
        protected abstract void SetupSpellCasting(List<Player> players);
    }
}