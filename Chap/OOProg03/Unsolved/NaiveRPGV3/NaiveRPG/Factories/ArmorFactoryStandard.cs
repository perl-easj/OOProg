using System;
using NaiveRPG.Helpers;
using NaiveRPG.Interfaces;
using NaiveRPG.Items.Armor;
using NaiveRPG.Items.Weapons;

namespace NaiveRPG.Factories
{
    public class ArmorFactoryStandard : IArmorFactory
    {
        public IArmor CreateArmor()
        {
            int index = RNG.RandomInt(1, 4);

            switch (index)
            {
                case 1:
                    return new ClothGloves();
                case 2:
                    return new LeatherBoots();
                case 3:
                    return new PlateBoots();
                case 4:
                    return new WoodenShield();
                default:
                    throw new Exception($"Could not generate armor with index {index}");
            }
        }
    }
}