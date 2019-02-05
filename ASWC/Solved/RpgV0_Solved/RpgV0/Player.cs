using System.Collections.Generic;
using System.Linq;

namespace RpgV0
{
    public class Player  // Not modified
    {
        public string Name { get; }
        public RoleType Role { get; }
        public List<Spell> AvailableSpells { get; }
        public List<Spell> CastedSpells { get; private set; }

        public Player(string name, RoleType role, List<Spell> availableSpells)
        {
            Name = name;
            Role = role;
            AvailableSpells = availableSpells;
            CastedSpells = new List<Spell>();
        }

        public void CastSpell(string spellDesc)
        {
            if (AvailableSpells.Any(sp => sp.Description == spellDesc) &&
                CastedSpells.All(sp => sp.Description != spellDesc))
            {
                CastedSpells.Add(AvailableSpells.Find(sp => sp.Description == spellDesc));
            }
        }

        public void UncastSpell(string spellDesc)
        {
            if (CastedSpells.Any(sp => sp.Description == spellDesc))
            {
                CastedSpells.Remove(CastedSpells.Find(sp => sp.Description == spellDesc));
            }
        }

        public void CastAllSpells()
        {
            CastedSpells = AvailableSpells;
        }

        public void UncastAllSpells()
        {
            CastedSpells = new List<Spell>();
        }

        public override string ToString()
        {
            return $"{Name} ({Role.ToString()})";
        }
    }
}