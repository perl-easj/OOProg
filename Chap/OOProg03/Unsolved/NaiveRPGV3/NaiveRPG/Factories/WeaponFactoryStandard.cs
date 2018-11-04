using System;
using NaiveRPG.Helpers;
using NaiveRPG.Interfaces;
using NaiveRPG.Items.Armor;
using NaiveRPG.Items.Weapons;

namespace NaiveRPG.Factories
{
    public class WeaponFactoryStandard : IWeaponFactory
    {
        public IWeapon CreateWeapon()
        {
            int index = RNG.RandomInt(1, 3);

            switch (index)
            {
                case 1:
                    return new IronSword();
                case 2:
                    return new SteelLance();
                case 3:
                    return new WoodenMace();
                default:
                    throw new Exception($"Could not generate item with index {index}");
            }
        }
    }
}