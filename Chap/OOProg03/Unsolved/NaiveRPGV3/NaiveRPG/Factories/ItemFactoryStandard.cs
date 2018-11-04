using System;
using NaiveRPG.Helpers;
using NaiveRPG.Interfaces;
using NaiveRPG.Items.Armor;
using NaiveRPG.Items.Weapons;

namespace NaiveRPG.Factories
{
    //public class ItemFactoryStandard : IItemFactory
    //{
    //    public IItem CreateItem()
    //    {
    //        int index = RNG.RandomInt(1, 7);

    //        switch (index)
    //        {
    //            case 1:
    //                return new ClothGloves();
    //            case 2:
    //                return new LeatherBoots();
    //            case 3:
    //                return new PlateBoots();
    //            case 4:
    //                return new WoodenShield();
    //            case 5:
    //                return new IronSword();
    //            case 6:
    //                return new SteelLance();
    //            case 7:
    //                return new WoodenMace();
    //            default:
    //                throw new Exception($"Could not generate item with index {index}");
    //        }
    //    }
    //}
}