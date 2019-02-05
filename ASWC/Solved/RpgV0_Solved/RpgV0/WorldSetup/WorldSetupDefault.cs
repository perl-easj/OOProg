using System.Collections.Generic;

namespace RpgV0.WorldSetup
{
    /// <summary>
    /// Class representing a full implementation of a "default" setup.
    /// The default setup is the setup used in the original version of
    /// the project.
    /// </summary>
    public class WorldSetupDefault : WorldSetupDefaultBase
    {
        /// <summary>
        /// Default Spell casting, as in the original version of the project.
        /// Each Player casts two Spells in an uncoordinated fashion.
        /// </summary>
        protected override void SetupSpellCasting(List<Player> players)
        {
            players[0].CastSpell(Spells[0].Description);
            players[0].CastSpell(Spells[2].Description);

            players[1].CastSpell(Spells[1].Description);
            players[1].CastSpell(Spells[4].Description);

            players[2].CastSpell(Spells[0].Description);
            players[2].CastSpell(Spells[6].Description);

            players[3].CastSpell(Spells[2].Description);
            players[3].CastSpell(Spells[4].Description);

            players[4].CastSpell(Spells[1].Description);
            players[4].CastSpell(Spells[6].Description);

            players[5].CastSpell(Spells[0].Description);
            players[5].CastSpell(Spells[1].Description);
        }
    }
}