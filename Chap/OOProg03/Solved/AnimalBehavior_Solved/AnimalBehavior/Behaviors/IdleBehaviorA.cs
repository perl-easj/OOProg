using System;
using AnimalBehavior.Interfaces;

namespace AnimalBehavior.Behaviors
{
    public class IdleBehaviorA : IAnimalBehavior
    {
        public void Act()
        {
            Console.WriteLine("[idle]  Zzzzzzzz....");
        }
    }
}