using System;
using AnimalBehavior.Interfaces;

namespace AnimalBehavior.Behaviors
{
    public class FearfulBehaviorA : IAnimalBehavior
    {
        public void Act()
        {
            Console.WriteLine("[Fearful]  Run!!");
        }
    }
}