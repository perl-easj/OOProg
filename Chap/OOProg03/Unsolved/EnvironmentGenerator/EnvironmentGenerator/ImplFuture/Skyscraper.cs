using EnvironmentGenerator.Interfaces;

namespace EnvironmentGenerator.ImplFuture
{
    public class Skyscraper : IBuilding
    {
        public string ElementDescription
        {
            get { return "Skyscraper"; }
        }

        public int Height
        {
            // All skyscrapers are 800 meters high...
            get { return 800; }
        }
    }
}