using System.Collections.Generic;

namespace SimpleCraft.Spells
{
    /// <summary>
    /// The SpellBook contain all valid spells which can be cast
    /// </summary>
    public class SpellBook
    {
        private static Dictionary<string, Spell> _spells = new Dictionary<string, Spell>
        {
            // Spell:        Description,   Short, Duration, DPS, Range
            { "a", new Spell("Acid Spill" , "a",   15,        2,  6) },
            { "l", new Spell("Lava Ground", "l",   10,        4,  5) },
            { "p", new Spell("Poison Gas" , "p",    5,       10,  6) },
            { "s", new Spell("Solar Flare", "s",    3,       20,  3) },
            { "x", new Spell("X-ray Burst", "x",    2,       35,  3) }
        };

        public static Spell LookupSpell(string shortName)
        {
            return _spells.ContainsKey(shortName) ? _spells[shortName] : null;
        }

        public static bool SpellExists(string shortName)
        {
            return _spells.ContainsKey(shortName);
        }
    }
}