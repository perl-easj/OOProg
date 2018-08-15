using EnvironmentGenerator.Interfaces;

namespace EnvironmentGenerator.Environment
{
    /// <summary>
    /// Straightforward (but flawed) implementation of 
    /// an environment generator.
    /// </summary>
    public class EnvironmentGeneratorBase : IEnvironmentGenerator
    {
        #region Instance fields
        private IBuildingFactory _buildingFactory;
        private ICreatureFactory _creatureFactory;
        private IWeaponFactory _weaponFactory;
        #endregion

        #region Constructor
        public EnvironmentGeneratorBase(IBuildingFactory buildingFactory, ICreatureFactory creatureFactory, IWeaponFactory weaponFactory)
        {
            _buildingFactory = buildingFactory;
            _creatureFactory = creatureFactory;
            _weaponFactory = weaponFactory;
        }
        #endregion

        #region Methods
        public IBuilding GenerateBuilding()
        {
            return _buildingFactory.Create();
        }

        public ICreature GenerateCreature()
        {
            return _creatureFactory.Create();
        }

        public IWeapon GenerateWeapon()
        {
            return _weaponFactory.Create();
        } 
        #endregion
    }
}