using EnvironmentGenerator.Interfaces;

namespace EnvironmentGenerator.ImplFuture
{
    public class BuildingFactoryFuture : IBuildingFactory
    {
        public IBuilding Create()
        {
            return new Skyscraper();
        }
    }
}