using System;
using System.Collections.Generic;
using System.Linq;


namespace RpgV0
{
    public class World
    {
        private List<Player> _players;

        public World()
        {
            Setup();
        }

        public Dictionary<string, int> DamagePercentages
        {
            get // TODO
            {
                Dictionary<string, int> damagePercentages = new Dictionary<string, int>();
                return damagePercentages;
            }
        }

        private void Setup()
        {
            #region The set of available spell types
            Spell spA = new Spell("Accelerated Thought", 15, new List<RoleType> { RoleType.Warrior, RoleType.Wizard });
            Spell spB = new Spell("Bulging Biceps", 25, new List<RoleType> { RoleType.Warrior, RoleType.Hunter });
            Spell spC = new Spell("Concentrated Aim", 10, new List<RoleType> { RoleType.Hunter, RoleType.Wizard });
            Spell spD = new Spell("Double Impact", 15, new List<RoleType> { RoleType.Warrior, RoleType.Hunter, RoleType.Wizard });
            Spell spE = new Spell("Essence of Evasion", 10, new List<RoleType> { RoleType.Hunter, RoleType.Warrior });
            Spell spF = new Spell("Furious Mind", 25, new List<RoleType> { RoleType.Wizard });
            Spell spG = new Spell("Greater Concentrated Aim", 20, new List<RoleType> { RoleType.Hunter, RoleType.Wizard });
            Spell spH = new Spell("Hastened Body", 10, new List<RoleType> { RoleType.Warrior, RoleType.Hunter });
            #endregion

            #region The set of players in the World
            Player pA = new Player("Alfredo", RoleType.Warrior, new List<Spell> { spA, spC, spE, spF, spH });
            Player pB = new Player("Beata", RoleType.Hunter, new List<Spell> { spB, spD, spE });
            Player pC = new Player("Calix", RoleType.Wizard, new List<Spell> { spA, spB, spD, spG });
            Player pD = new Player("Dornato", RoleType.Warrior, new List<Spell> { spC, spD, spE, spF });
            Player pE = new Player("Edriel", RoleType.Hunter, new List<Spell> { spB, spG, spH });
            Player pF = new Player("Fumigo", RoleType.Hunter, new List<Spell> { spA, spB, spD });

            _players = new List<Player> { pA, pB, pC, pD, pE, pF};
            #endregion

            #region Each Player may now cast two spells.
            pA.CastSpell(spA.Description);
            pA.CastSpell(spC.Description);

            pB.CastSpell(spB.Description);
            pB.CastSpell(spE.Description);

            pC.CastSpell(spA.Description);
            pC.CastSpell(spG.Description);

            pD.CastSpell(spC.Description);
            pD.CastSpell(spE.Description);

            pE.CastSpell(spB.Description);
            pE.CastSpell(spG.Description);

            pF.CastSpell(spA.Description);
            pF.CastSpell(spB.Description);
            #endregion
        }
    }
}