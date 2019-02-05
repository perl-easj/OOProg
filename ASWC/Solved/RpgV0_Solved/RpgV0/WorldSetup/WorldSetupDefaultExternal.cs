using System.Collections.Generic;

namespace RpgV0.WorldSetup
{
    /// <summary>
    /// This class executes the "default" world setup strategy; it is just
    /// included to show how the WorldSetupExternalSpellStrat class can be
    /// used for providing an externally defined spell casting strategy.
    /// </summary>
    public class WorldSetupDefaultExternal : WorldSetupExternalSpellStrat
    {
        public WorldSetupDefaultExternal() 
            : base(new List<List<int>>
            {
                // The i'th element in this list defines the Spell casting strategy
                // for Player i. Example: Player 3 casts Spells 2 and 4.
                new List<int>{0, 2},
                new List<int>{1, 4},
                new List<int>{0, 6},
                new List<int>{2, 4},
                new List<int>{1, 6},
                new List<int>{0, 1}
            })
        {
        }
    }
}