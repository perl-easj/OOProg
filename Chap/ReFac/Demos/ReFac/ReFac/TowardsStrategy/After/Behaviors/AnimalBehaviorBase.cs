namespace ReFac.TowardsStrategy.After.Behaviors
{
    public class AnimalBehaviorBase
    {
        protected AnimalBehaviorLib BehaviorLib { get; }

        public AnimalBehaviorBase()
        {
            BehaviorLib = new AnimalBehaviorLib();
        }
    }
}