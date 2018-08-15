using EnvironmentGenerator.Interfaces;

namespace EnvironmentGenerator.ImplFuture
{
    public class WeaponFactoryFuture : IWeaponFactory
    {
        public IWeapon Create()
        {
            return new Phaser();
        }
    }
}