using ReFac.TowardsStrategy.Shared;

namespace ReFac.TowardsStrategy.After.Behaviors
{
    public class AggressiveBehavior : AnimalBehaviorBase, IAnimalBehavior
    {
        public void Act()
        {
            if (BehaviorLib.CloseBy("Mouse"))
                BehaviorLib.Kill("Mouse");

            if (BehaviorLib.CloseBy("Sheep"))
                BehaviorLib.Kill("Sheep");
        }
    }
}