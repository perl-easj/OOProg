using System.Collections.Generic;
using System.Linq;

namespace RpgV0.WorldSetup
{
    /// <summary>
    /// Class representing a more coordinated world setup,
    /// specifically w.r.t. Spellcasting.
    /// </summary>
    public class WorldSetupCoordinated : WorldSetupDefaultBase
    {
        protected override void SetupSpellCasting(List<Player> players)
        {
            Dictionary<string, int> spellRank = new Dictionary<string, int>();

            // Calculate the "rank" of each Spell, The rank is defined as:
            // 1) Benefit percentage of Spell, multiplied by
            // 2) The number of Players affected by the Spell.
            // The description of the Spell is used as key.
            foreach (Spell aSpell in Spells)
            {
                int rank = aSpell.BenefitPercent * players.Count(p => aSpell.Beneficiaries.Contains(p.Role));
                spellRank.Add(aSpell.Description, rank);
            }

            // Transform the Spell rank Dictionary into a List of Spell descriptions,
            // ordered by rank value in descending order (i.e. "best" Spell first).
            IEnumerable<string> spellDesc = spellRank.OrderBy(kvp => kvp.Value).Select(kvp => kvp.Key).Reverse();

            // Now try to cast each Spell, starting with the best Spells first.
            foreach (string desc in spellDesc)
            {
                // Find a Player (if any) that
                // 1) Can still cast spells, i.e. has cast less than two spells currently
                // 2) Can cast the spell in question

                Player caster = players
                    .Where(p => p.CastedSpells.Count < 2)
                    .FirstOrDefault(p => p.AvailableSpells.Select(s => s.Description).Contains(desc));

                // Now actually cast the Spell (if a Player was found)
                caster?.CastSpell(desc);
            }
        }
    }
}