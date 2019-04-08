using ReFac.TowardsStrategy.Shared;

namespace ReFac.TowardsStrategy.After.Behaviors
{
    public class IdleBehavior : AnimalBehaviorBase, IAnimalBehavior
    {
        public void Act()
        {
            if (!BehaviorLib.CloseBy("Tiger"))
                BehaviorLib.Sleep();
            else
                BehaviorLib.Alert();
        }
    }
}