using System;
using System.Collections.Generic;

namespace FOOrrestGump.FGScenarioChanged
{
    /// <summary>
    /// A Factory-like class for generating a Chocolate object.
    /// CHANGED: Now generates ChocolateChanged objects
    /// </summary>
    public class ChocolateGeneratorChanged
    {
        private static Random _rng;
        private static List<ChocolateChanged.FlavorType> _flavorTypes;

        static ChocolateGeneratorChanged()
        {
            _rng = new Random(Guid.NewGuid().GetHashCode());
            _flavorTypes = new List<ChocolateChanged.FlavorType>();

            foreach (ChocolateChanged.FlavorType flavor in Enum.GetValues(typeof(ChocolateChanged.FlavorType)))
            {
                _flavorTypes.Add(flavor);
            }
        }

        public ChocolateChanged GenerateChocolate()
        {
            return new ChocolateChanged(_flavorTypes[_rng.Next(_flavorTypes.Count)]);
        }
    }
}