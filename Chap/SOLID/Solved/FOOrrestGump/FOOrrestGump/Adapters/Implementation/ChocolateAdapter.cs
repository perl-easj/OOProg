using FOOrrestGump.Adapters.Interfaces;
using FOOrrestGump.FGScenario;

namespace FOOrrestGump.Adapters.Implementation
{
    /// <summary>
    /// Specific implementation of an adapter of Chocolate to IConsumable.
    /// </summary>
    public class ChocolateAdapter : AdapterBase<Chocolate>, IConsumableAdapter<Chocolate>
    {
        public ChocolateAdapter(Chocolate adaptee) : base(adaptee)
        {
        }
    }
}