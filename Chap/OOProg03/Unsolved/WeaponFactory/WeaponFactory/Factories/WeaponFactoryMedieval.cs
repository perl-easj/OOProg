using System;
using WeaponFactory.Interfaces;
using WeaponFactory.Weapons;

namespace WeaponFactory.Factories
{
    /// <summary>
    /// Weapon factory class for medieval weapons.
    /// </summary>
    public class WeaponFactoryMedieval : IWeaponFactory
    {
        public IWeapon Create(WeaponType type)
        {
            // You can do better than that...
            return null;
        }
    }
}