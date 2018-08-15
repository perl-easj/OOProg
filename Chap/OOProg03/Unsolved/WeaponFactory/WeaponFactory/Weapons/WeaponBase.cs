using WeaponFactory.Interfaces;

namespace WeaponFactory.Weapons
{
    /// <summary>
    /// Base class for all weapons
    /// </summary>
    public abstract class WeaponBase : IWeapon
    {
        public abstract string Description { get; }
        public abstract int Damage { get; }

        public override string ToString()
        {
            return $"{Description}, dealing {Damage} damage points";
        }
    }
}