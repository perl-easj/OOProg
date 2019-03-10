using System;
using System.Collections.Generic;

namespace FOOrrestGump.FGScenario
{
    /// <summary>
    /// A Factory-like class for generating a Chocolate object.
    /// </summary>
    public class ChocolateGenerator
    {
        private static Random _rng;
        private static List<Chocolate.FlavorType> _flavorTypes;

        static ChocolateGenerator()
        {
            _rng = new Random(Guid.NewGuid().GetHashCode());
            _flavorTypes = new List<Chocolate.FlavorType>();

            foreach (Chocolate.FlavorType flavor in Enum.GetValues(typeof(Chocolate.FlavorType)))
            {
                _flavorTypes.Add(flavor);
            }
        }

        public Chocolate GenerateChocolate()
        {
            return new Chocolate(_flavorTypes[_rng.Next(_flavorTypes.Count)]);
        }
    }
}