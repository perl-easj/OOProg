using System;
using AnimalBehavior.Interfaces;

namespace AnimalBehavior.Behaviors
{
    public class IdleBehaviorB : IAnimalBehavior
    {
        public void Act()
        {
            Console.WriteLine("[Idle]  I will now enter a period of being passive");
        }
    }
}