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
            if (type == WeaponType.Melee) return new Dagger();
            if (type == WeaponType.Ranged) return new CrossBow();
            if (type == WeaponType.Magic) return new Wand();

            throw new ArgumentException($"WeaponFactoryMedieval - no class available for weapon type {type}");
        }
    }
}