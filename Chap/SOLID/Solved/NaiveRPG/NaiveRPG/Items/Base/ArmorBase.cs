using System;

namespace NaiveRPG
{
    public class ArmorBase : ItemBase
    {
        public ArmorSlot Slot { get; }

        public ArmorBase(
            string description, 
            int valueInGold,
            ArmorSlot slot) 
            : base(description, valueInGold, ItemCategory.armor)
        {
            Slot = slot;
        }
    }
}