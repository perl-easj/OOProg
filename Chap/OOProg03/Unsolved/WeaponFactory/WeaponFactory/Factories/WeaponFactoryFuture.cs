using System;
using WeaponFactory.Interfaces;
using WeaponFactory.Weapons;

namespace WeaponFactory.Factories
{
    /// <summary>
    /// Weapon factory class for futuristic weapons.
    /// </summary>
    public class WeaponFactoryFuture : IWeaponFactory
    {
        public IWeapon Create(WeaponType type)
        {
            // You can do better than that...
            return null;
        }
    }
}