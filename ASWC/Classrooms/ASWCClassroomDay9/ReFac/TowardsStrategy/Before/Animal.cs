using System;
using ReFac.TowardsStrategy.After;
using ReFac.TowardsStrategy.Shared;

namespace ReFac.TowardsStrategy.Before
{
    public class Animal : IAnimalBehavior
    {
        public string Description { get; }
        public AnimalState State { get; set; }

        public Animal(string description, AnimalState state = AnimalState.idle)
        {
            Description = description;
            State = state;
        }

        public void Act()
        {
            if (State == AnimalState.aggressive)
            {
                if (CloseBy("Mouse"))
                    Kill("Mouse");

                if (CloseBy("Sheep"))
                    Kill("Sheep");
            }
            else if (State == AnimalState.fearful)
            {
                if (CloseBy("Mouse") || CloseBy("Fox"))
                    RunAway();
            }
            else if (State == AnimalState.idle)
            {
                if (!CloseBy("Tiger"))
                    Sleep();
                else
                    Alert();
            }
            else
            {
                throw new NotImplementedException($"No behavior matching the state {State}");
            }
        }

        private bool CloseBy(string animalDesc)
        {
            return true;
        }

        private void Kill(string animalDesc)
        {
            Console.WriteLine($"{animalDesc} was killed...");
        }

        private void Sleep()
        {
            Console.WriteLine($"zzzZZZzzz...");
        }

        private void Alert()
        {
            Console.WriteLine($"Watching...");
        }

        private void RunAway()
        {
            Console.WriteLine($"Oh no, I'm running away now!");
        }
    }
}