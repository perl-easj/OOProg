namespace FOOrrestGump.FGScenario
{
    /// <summary>
    /// Class representing one piece of Chocolate.
    /// </summary>
    public class Chocolate
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

        public Chocolate(FlavorType flavor)
        {
            _flavor = flavor;
        }

        public FlavorType Flavor
        {
            get { return _flavor; }
        }
    }
}