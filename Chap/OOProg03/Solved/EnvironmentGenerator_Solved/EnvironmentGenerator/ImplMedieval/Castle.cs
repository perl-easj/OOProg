using EnvironmentGenerator.Interfaces;

namespace EnvironmentGenerator.ImplMedieval
{
    public class Castle : IBuilding
    {
        public string ElementDescription
        {
            get { return "Castle"; }
        }

        public int Height
        {
            // All castles are 25 meters high...
            get { return 25; }
        }
    }
}