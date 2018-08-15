using EnvironmentGenerator.Interfaces;

namespace EnvironmentGenerator.ImplMedieval
{
    public class WeaponFactoryMedieval : IWeaponFactory
    {
        public IWeapon Create()
        {
            return new Sword();
        }
    }
}