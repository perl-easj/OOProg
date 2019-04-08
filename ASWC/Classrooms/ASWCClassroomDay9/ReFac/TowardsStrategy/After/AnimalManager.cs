using System.Collections.Generic;
using ReFac.TowardsStrategy.After.Behaviors;
using ReFac.TowardsStrategy.Shared;

namespace ReFac.TowardsStrategy.After
{
    public class AnimalManager
    {
        private Dictionary<AnimalState, IAnimalBehavior> _behaviors;

        public AnimalManager()
        {
            _behaviors = new Dictionary<AnimalState, IAnimalBehavior>();
            _behaviors.Add(AnimalState.aggressive, new AggressiveBehavior());
            _behaviors.Add(AnimalState.fearful, new FearfulBehavior());
            _behaviors.Add(AnimalState.idle, new IdleBehavior());
        }

        public void SetBehavior(AnimalState state, IAnimalBehavior behavior)
        {
            _behaviors[state] = behavior;
        }

        public Animal Create(string desc, AnimalState initState = AnimalState.idle)
        {
            return new Animal(desc, _behaviors[initState]);
        }

        public void ChangeBehavior(Animal anAnimal, AnimalState state)
        {
            anAnimal.Behavior = _behaviors[state];
        }
    }
}