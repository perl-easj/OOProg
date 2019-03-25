using System;
using AnimalBehavior.Interfaces;

namespace AnimalBehavior.Behaviors
{
    public class FearfulBehaviorB : IAnimalBehavior
    {
        public void Act()
        {
            Console.WriteLine("[Fearful]  I will now run away and hide...");
        }
    }
}