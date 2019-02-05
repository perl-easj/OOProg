using System.Collections.Generic;

namespace RpgV0.WorldSetup
{
    /// <summary>
    /// This class represents a "default" setup w.r.t. Spell objects
    /// </summary>
    public class SpellSetupDefault
    {
        /// <summary>
        /// Returns a "default" setup of Spell objects.
        /// </summary>
        public static List<Spell> SpellSetup
        {
            get
            {
                Spell sp0 = new Spell("Accelerated Thought", 15, new List<RoleType> { RoleType.Warrior, RoleType.Wizard });
                Spell sp1 = new Spell("Bulging Biceps", 25, new List<RoleType> { RoleType.Warrior, RoleType.Hunter });
                Spell sp2 = new Spell("Concentrated Aim", 10, new List<RoleType> { RoleType.Hunter, RoleType.Wizard });
                Spell sp3 = new Spell("Double Impact", 15, new List<RoleType> { RoleType.Warrior, RoleType.Hunter, RoleType.Wizard });
                Spell sp4 = new Spell("Essence of Evasion", 10, new List<RoleType> { RoleType.Hunter, RoleType.Warrior });
                Spell sp5 = new Spell("Furious Mind", 25, new List<RoleType> { RoleType.Wizard });
                Spell sp6 = new Spell("Greater Concentrated Aim", 20, new List<RoleType> { RoleType.Hunter, RoleType.Wizard });
                Spell sp7 = new Spell("Hastened Body", 10, new List<RoleType> { RoleType.Warrior, RoleType.Hunter });

                List<Spell> spells = new List<Spell> { sp0, sp1, sp2, sp3, sp4, sp5, sp6, sp7 };
                return spells;
            }
        }
    }
}