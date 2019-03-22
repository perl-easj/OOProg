using System;
using WildLife.Common;

namespace WildLife.CoR
{
    public class AnimalBehavior :  IAnimalBehavior
    { 
        private IAnimalBehavior Next { get; }
        private Func<bool> Criterion { get; }
        protected Action Behavior { get; }

        public AnimalBehavior(AnimalBase animal, Action behavior, Func<bool> criterion, IAnimalBehavior next)
        {
            Behavior = behavior;
            Criterion = criterion;
            Next = next;
        }

        public void Act()
        {
            if (Criterion())
            {
                Behavior();
            }
            else
            {
                Next?.Act();
            }
        }
    }
}