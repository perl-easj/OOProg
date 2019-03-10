using FOOrrestGump.Interfaces;

namespace FOOrrestGump.FGScenarioChanged
{
    /// <summary>
    /// Class representing one piece of Chocolate.
    /// CHANGED: Now implements IConsumable
    /// </summary>
    public class ChocolateChanged : IConsumable
    {
        public enum FlavorType
        {
            Milk,
            Dark,
            Cherry,
            Strawberry,
            Orange,
            Coffee,
            Nougat
        }

        private FlavorType _flavor;

        public ChocolateChanged(FlavorType flavor)
        {
            _flavor = flavor;
        }

        public FlavorType Flavor
        {
            get { return _flavor; }
        }
    }
}