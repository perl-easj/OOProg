using FOOrrestGump.FGScenarioChanged;
using FOOrrestGump.Interfaces;

namespace FOOrrestGump.Implementation
{
    /// <summary>
    /// Specific implementation of a Factory for the
    /// Forrest Gump + Box of Chocolates scenario.
    /// </summary>
    public class ForrestGumpScenarioFactoryChanged : IScenarioFactory<ChocolateChanged>
    {
        private ChocolateBoxGeneratorChanged _chocolateBoxGenerator;
        private ForrestGumpGeneratorChanged _forrestGumpGenerator;

        public ForrestGumpScenarioFactoryChanged()
        {
            _chocolateBoxGenerator = new ChocolateBoxGeneratorChanged();
            _forrestGumpGenerator = new ForrestGumpGeneratorChanged();
        }

        IConsumer<ChocolateChanged> IScenarioFactory<ChocolateChanged>.CreateConsumer()
        {
            return _forrestGumpGenerator.GenerateForrestGump();
        }

        IConsumableContainer<ChocolateChanged> IScenarioFactory<ChocolateChanged>.CreateContainer()
        {
            return _chocolateBoxGenerator.GenerateChocolateBox();
        }
    }
}