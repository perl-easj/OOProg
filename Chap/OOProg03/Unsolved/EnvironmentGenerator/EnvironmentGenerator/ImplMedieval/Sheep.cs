using EnvironmentGenerator.Interfaces;

namespace EnvironmentGenerator.ImplMedieval
{
    public class Sheep : ICreature
    {
        public string ElementDescription
        {
            get { return "Sheep"; }
        }

        public string Description
        {
            get { return "Docile Sheep"; }
        }
    }
}