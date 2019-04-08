using System;

namespace ReFac.TowardsStrategy.After
{
    public class AnimalBehaviorLib
    {
        public bool CloseBy(string animalDesc)
        {
            return true;
        }

        public void Kill(string animalDesc)
        {
            Console.WriteLine($"{animalDesc} was killed...");
        }

        public void Sleep()
        {
            Console.WriteLine($"zzzZZZzzz...");
        }

        public void Alert()
        {
            Console.WriteLine($"Watching...");
        }

        public void RunAway()
        {
            Console.WriteLine($"Oh no, I'm running away now!");
        }
    }
}