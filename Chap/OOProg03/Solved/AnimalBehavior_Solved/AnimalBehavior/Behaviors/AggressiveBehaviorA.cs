using System;
using AnimalBehavior.Interfaces;

namespace AnimalBehavior.Behaviors
{
    public class AggressiveBehaviorA : IAnimalBehavior
    {
        public void Act()
        {
            Console.WriteLine("[Aggressive]  Grrr...");
        }
    }
}