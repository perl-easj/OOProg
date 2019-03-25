using System;
using AnimalBehavior.Interfaces;

namespace AnimalBehavior
{
    public class Tester
    {
        private static Random _rng = new Random(Guid.NewGuid().GetHashCode());

        public void Run()
        {
            // Create a test animal
            IAnimal anAnimal = null; // ...so this should be changed, of course :-)

            // In each iteration, the Animal should
            // 1) Act in a way that depends on its current state.
            // 2) Possibly change its state.
            for (int i = 0; i < 10; i++)
            {
                anAnimal.Act();
                anAnimal.CurrentState = GenerateAnimalState();
            }
        }

        private AnimalState GenerateAnimalState()
        {
            var enums = Enum.GetValues(typeof(AnimalState));
            return (AnimalState)enums.GetValue(_rng.Next(enums.Length));
        }
    }
}