using System;
using AnimalBehavior.Interfaces;

namespace AnimalBehavior.Behaviors
{
    public class AggressiveBehaviorB : IAnimalBehavior
    {
        public void Act()
        {
            Console.WriteLine("[Aggressive]  I will attack you within a short period of time...");
        }
    }
}