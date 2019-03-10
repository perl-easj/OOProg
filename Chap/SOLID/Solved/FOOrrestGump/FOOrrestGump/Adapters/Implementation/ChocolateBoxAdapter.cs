using FOOrrestGump.Adapters.Interfaces;
using FOOrrestGump.FGScenario;

namespace FOOrrestGump.Adapters.Implementation
{
    /// <summary>
    /// Specific implementation of an adapter of ChocolateBox to IConsumableContainer.
    /// </summary>
    public class ChocolateBoxAdapter : AdapterBase<ChocolateBox>, IConsumableContainerAdapter<IConsumableAdapter<Chocolate>, ChocolateBox>
    {
        private ChocolateBox _chocolateBox;

        public ChocolateBoxAdapter(ChocolateBox chocolateBox) : base(chocolateBox)
        {
            _chocolateBox = chocolateBox;
        }

        public bool Empty
        {
            get { return !_chocolateBox.ChocolateLeft; }
        }

        public IConsumableAdapter<Chocolate> TakeNext()
        {
            return new ChocolateAdapter(_chocolateBox.TakeAChocolate());
        }
    }
}