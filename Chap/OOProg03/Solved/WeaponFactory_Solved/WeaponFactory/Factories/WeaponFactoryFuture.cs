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
            if (type == WeaponType.Melee) return new TazerKnuckles();
            if (type == WeaponType.Ranged) return new Phaser();
            if (type == WeaponType.Magic) return new VacuumEnergyChanneler();

            throw new ArgumentException($"WeaponFactoryFuture - no class available for weapon type {type}");
        }
    }
}