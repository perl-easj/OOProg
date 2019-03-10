using System;
using System.Collections.Generic;
using FOOrrestGump.Interfaces;

namespace FOOrrestGump.FGScenarioChanged
{
    /// <summary>
    /// Class representing Forrest Gump (well, parts of him...).
    /// CHANGED: Now implements IConsumer
    /// </summary>
    public class ForrestGumpChanged : IConsumer<ChocolateChanged>
    {
        private Dictionary<ChocolateChanged.FlavorType, string> _chocolateAttitudes;

        public ForrestGumpChanged()
        {
            _chocolateAttitudes = new Dictionary<ChocolateChanged.FlavorType, string>();
            _chocolateAttitudes.Add(ChocolateChanged.FlavorType.Dark, "really like");
            _chocolateAttitudes.Add(ChocolateChanged.FlavorType.Coffee, "don't really like");
            _chocolateAttitudes.Add(ChocolateChanged.FlavorType.Milk, "really, really like");
            _chocolateAttitudes.Add(ChocolateChanged.FlavorType.Cherry, "really enjoy");
            _chocolateAttitudes.Add(ChocolateChanged.FlavorType.Orange, "have mixed feelings about");
        }

        public void Eat(ChocolateChanged aChocolate)
        {
            Console.WriteLine($"You know, I {ChocolateAttitude(aChocolate)} {aChocolate.Flavor.ToString()} choc-a-lates...");
        }

        public void SayFavoriteProverb()
        {
            Console.WriteLine("Life is like a box of choc-a-lates. You never know what you're gonna get...");
        }

        private string ChocolateAttitude(ChocolateChanged aChocolate)
        {
            return _chocolateAttitudes.ContainsKey(aChocolate.Flavor) ? 
                _chocolateAttitudes[aChocolate.Flavor] : 
                "don't know to to feel about";
        }

        public void PreConsumeAction()
        {
            SayFavoriteProverb();
        }

        public void Consume(ChocolateChanged aConsumable)
        {
            Eat(aConsumable);
        }

        public void PostConsumeAction()
        {
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}