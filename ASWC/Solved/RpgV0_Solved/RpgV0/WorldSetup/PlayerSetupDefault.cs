using System.Collections.Generic;

namespace RpgV0.WorldSetup
{
    /// <summary>
    /// This class represents a "default" setup w.r.t. Player objects
    /// </summary>
    public class PlayerSetupDefault
    {
        /// <summary>
        /// Returns a "default" setup of Player objects. It is assumed that the
        /// provided List of Spell objects also represents a default setup of Spells.
        /// </summary>
        public static List<Player> PlayerSetup(List<Spell> spells)
        {
            Player pA = new Player("Alfredo", RoleType.Warrior, new List<Spell> { spells[0], spells[2], spells[4], spells[5], spells[7] });
            Player pB = new Player("Beata", RoleType.Hunter, new List<Spell> { spells[1], spells[3], spells[4] });
            Player pC = new Player("Calix", RoleType.Wizard, new List<Spell> { spells[0], spells[1], spells[3], spells[6] });
            Player pD = new Player("Dornato", RoleType.Warrior, new List<Spell> { spells[2], spells[3], spells[4], spells[5] });
            Player pE = new Player("Edriel", RoleType.Hunter, new List<Spell> { spells[1], spells[6], spells[7] });
            Player pF = new Player("Fumigo", RoleType.Hunter, new List<Spell> { spells[0], spells[1], spells[3] });

            List<Player> players = new List<Player> {pA, pB, pC, pD, pE, pF};
            return players;
        }
    }
}