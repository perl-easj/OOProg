using System;
using System.Collections.Generic;

namespace FOOrrestGump.FGScenario
{
    /// <summary>
    /// Class representing Forrest Gump (well, parts of him...).
    /// </summary>
    public class ForrestGump
    {
        private Dictionary<Chocolate.FlavorType, string> _chocolateAttitudes;

        public ForrestGump()
        {
            _chocolateAttitudes = new Dictionary<Chocolate.FlavorType, string>();
            _chocolateAttitudes.Add(Chocolate.FlavorType.Dark, "really like");
            _chocolateAttitudes.Add(Chocolate.FlavorType.Coffee, "don't really like");
            _chocolateAttitudes.Add(Chocolate.FlavorType.Milk, "really, really like");
            _chocolateAttitudes.Add(Chocolate.FlavorType.Cherry, "really enjoy");
            _chocolateAttitudes.Add(Chocolate.FlavorType.Orange, "have mixed feelings about");
        }

        public void Eat(Chocolate aChocolate)
        {
            Console.WriteLine($"You know, I {ChocolateAttitude(aChocolate)} {aChocolate.Flavor.ToString()} choc-a-lates...");
        }

        public void SayFavoriteProverb()
        {
            Console.WriteLine("Life is like a box of choc-a-lates. You never know what you're gonna get...");
        }

        private string ChocolateAttitude(Chocolate aChocolate)
        {
            return _chocolateAttitudes.ContainsKey(aChocolate.Flavor) ? 
                _chocolateAttitudes[aChocolate.Flavor] : 
                "don't know how to feel about";
        }
    }
}