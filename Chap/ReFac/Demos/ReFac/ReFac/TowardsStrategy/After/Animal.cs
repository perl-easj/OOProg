using System;
using ReFac.TowardsStrategy.Shared;

namespace ReFac.TowardsStrategy.After
{
    public class Animal : IAnimalBehavior
    {
        public string Description { get; }
        public IAnimalBehavior Behavior { get; set; }

        public Animal(string description, IAnimalBehavior behavior)
        {
            Behavior = behavior ?? throw new ArgumentException("Null for initial behavior not allowed...");
            Description = description;
        }

        public void Act()
        {
            Behavior.Act();
        }
    }
}