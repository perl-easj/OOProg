using System;
using System.Collections.Generic;
using System.Linq;

namespace RpgV1.Spells
{
    public class Spell
    {
        /// <summary>
        /// Convenient property for retrieving a list of all spell types.
        /// </summary>
        public static IEnumerable<SpellType> SpellTypeList
        {
            get { return Enum.GetValues(typeof(SpellType)).Cast<SpellType>(); }
        }
    }
}