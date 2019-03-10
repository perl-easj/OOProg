using FOOrrestGump.Adapters;
using FOOrrestGump.Adapters.Implementation;
using FOOrrestGump.Adapters.Interfaces;
using FOOrrestGump.FGScenario;
using FOOrrestGump.Interfaces;

namespace FOOrrestGump.Implementation
{
    /// <summary>
    /// Specific implementation of a Factory for the
    /// Forrest Gump + Box of Chocolates scenario.
    /// </summary>
    public class ForrestGumpScenarioFactoryAdapters : IScenarioFactory<IConsumableAdapter<Chocolate>>
    {
        private ChocolateBoxGenerator _chocolateBoxGenerator;
        private ForrestGumpGenerator _forrestGumpGenerator;

        public ForrestGumpScenarioFactoryAdapters()
        {
            _chocolateBoxGenerator = new ChocolateBoxGenerator();
            _forrestGumpGenerator = new ForrestGumpGenerator();
        }

        public IConsumer<IConsumableAdapter<Chocolate>> CreateConsumer()
        {
            return new ForrestGumpAdapter(_forrestGumpGenerator.GenerateForrestGump());
        }

        public IConsumableContainer<IConsumableAdapter<Chocolate>> CreateContainer()
        {
            return new ChocolateBoxAdapter(_chocolateBoxGenerator.GenerateChocolateBox());
        }
    }
}