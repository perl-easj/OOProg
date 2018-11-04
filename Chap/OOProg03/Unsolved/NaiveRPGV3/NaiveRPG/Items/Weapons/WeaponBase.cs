using NaiveRPG.Helpers;
using NaiveRPG.Interfaces;

namespace NaiveRPG.Items.Weapons
{
    /// <summary>
    /// Base class for all items considered to be weapons.
    /// </summary>
    public abstract class WeaponBase : ItemBase, IWeapon
    {
        public int MaxWeaponDamage { get; private set; }

        protected WeaponBase()
        {
            MaxWeaponDamage = RNG.RandomInt(1, MaxMaxWeaponDamage);
        }

        public override string Description
        {
            get { return $"{Name} (max. {MaxWeaponDamage} weapon damage)"; }
        }

        public abstract int MaxMaxWeaponDamage { get; }

        public abstract string Name { get; }
    }
}