using EnvironmentGenerator.ImplMedieval;
using EnvironmentGenerator.Interfaces;

namespace EnvironmentGenerator.ImplFuture
{
    public class CreatureFactoryFuture : ICreatureFactory
    {
        public ICreature Create()
        {
            return new Robot();
        }
    }
}