using EnvironmentGenerator.Interfaces;

namespace EnvironmentGenerator.ImplFuture
{
    public class Robot : ICreature
    {
        public string ElementDescription
        {
            get { return "Robot"; }
        }

        public string Description
        {
            get { return "Vicious Robot"; }
        }
    }
}