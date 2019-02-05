using System.Collections.Generic;
using System.Linq;

namespace RpgV0
{
    public class World // Modified
    {
        private List<Player> _players;

        // The entire setup of Spells, Players and spell casting has been removed
        // from the World class, and is now "injected" through the single parameter
        // to the constructor, of type IWorldSetup.
        public World(IWorldSetup worldSetup) // Modified
        {
            _players = worldSetup.Setup();
        }

        // Now returns the correct damage percentages for each Player
        public Dictionary<string, int> DamagePercentages // Modified 
        {
            get
            {
                Dictionary<string, int> damagePercentages = new Dictionary<string, int>();               
                _players.ForEach(p => damagePercentages.Add(p.ToString(), DamagePercentage(p.Role))); // Added
                return damagePercentages;
            }
        }

        // This - very important - helper method can calculate the
        // damage percentage for the given role. 
        private int DamagePercentage(RoleType role) // Added
        {
            return 100 + _players
                       .SelectMany(p => p.CastedSpells) // Pick up list of ALL spells casted by players...
                       .Distinct() // ... then clean up the list, so each element is unique, since each spell can only affect a Player once...
                       .Where(cs => cs.Beneficiaries.Contains(role)) // ... then reduce then list to those spells which are beneficial to the given role...
                       .Select(bs => bs.BenefitPercent) // ...then select the benefit percentage for these spells...
                       .Sum();  // ...and sum them up!
        }
    }
}