using ReFac.TowardsStrategy.Shared;

namespace ReFac.TowardsStrategy.After.Behaviors
{
    public class FearfulBehavior : AnimalBehaviorBase, IAnimalBehavior
    {
        public void Act()
        {
            if (BehaviorLib.CloseBy("Mouse") || BehaviorLib.CloseBy("Fox"))
                BehaviorLib.RunAway();
        }
    }
}