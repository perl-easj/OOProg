using EnvironmentGenerator.Interfaces;

namespace EnvironmentGenerator.ImplMedieval
{
    public class BuildingFactoryMedieval : IBuildingFactory
    {
        public IBuilding Create()
        {
            return new Castle();
        }
    }
}