using EnvironmentGenerator.Interfaces;

namespace EnvironmentGenerator.ImplMedieval
{
    public class CreatureFactoryMedieval : ICreatureFactory
    {
        public ICreature Create()
        {
            return new Sheep();
        }
    }
}