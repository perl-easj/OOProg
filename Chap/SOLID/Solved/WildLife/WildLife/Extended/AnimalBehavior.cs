using System;

namespace WildLife.Extended
{
    public class AnimalBehavior
    {
        public Func<bool> Condition { get; }
        public Action Behavior { get; }

        public AnimalBehavior(Func<bool> condition, Action behavior)
        {
            Condition = condition;
            Behavior = behavior;
        }

        public bool DoBehavior()
        {
            if (Condition())
            {
                Behavior();
                return true;
            }

            return false;
        }
    }
}