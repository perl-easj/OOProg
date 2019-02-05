using System.Collections.Generic;

namespace RpgV0.WorldSetup
{
    /// <summary>
    /// This class is intended to be a base class for any "default" world setup.
    /// That is, any setup which uses the default Spell and Player objects.
    /// </summary>
    public abstract class WorldSetupDefaultBase : WorldSetupBase
    {
        protected override List<Spell> SetupSpells()
        {
            return SpellSetupDefault.SpellSetup;
        }

        protected override List<Player> SetupPlayers(List<Spell> spells)
        {
            return PlayerSetupDefault.PlayerSetup(spells);
        }
    }
}