using AnimalBehavior.Behaviors;
using AnimalBehavior.Interfaces;

namespace AnimalBehavior.Factories
{
    public class AnimalBehaviorFactorySimple : IAnimalBehaviorFactory
    {
        public IAnimalBehavior CreateAggressiveBehavior()
        {
            return new AggressiveBehaviorA();
        }

        public IAnimalBehavior CreateFearfulBehavior()
        {
            return new FearfulBehaviorA();
        }

        public IAnimalBehavior CreateIdleBehavior()
        {
            return new IdleBehaviorA();
        }
    }
}