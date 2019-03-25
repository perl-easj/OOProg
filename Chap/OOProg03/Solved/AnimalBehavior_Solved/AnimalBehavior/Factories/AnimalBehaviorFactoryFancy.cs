using AnimalBehavior.Behaviors;
using AnimalBehavior.Interfaces;

namespace AnimalBehavior.Factories
{
    public class AnimalBehaviorFactoryFancy : IAnimalBehaviorFactory
    {
        public IAnimalBehavior CreateAggressiveBehavior()
        {
            return new AggressiveBehaviorB();
        }

        public IAnimalBehavior CreateFearfulBehavior()
        {
            return new FearfulBehaviorB();
        }

        public IAnimalBehavior CreateIdleBehavior()
        {
            return new IdleBehaviorB();
        }
    }
}