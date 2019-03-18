using System;

namespace NaiveRPG.Factories
{
    public class ArmorFactoryRandomized : RandomizedFactory<IItem>
    {
        public ArmorFactoryRandomized()
        {
            AddFactoryMethod(50, CreateBoots);
            AddFactoryMethod(50, CreateChest);
        }

        // Could later on generate "subclasses" of Boots
        private Boots CreateBoots()
        {
            return new Boots(description, valueInGold); 
        }

        // Could later on generate "subclasses" of Chest
        private Chest CreateChest()
        {
            return new Chest(description, valueInGold);
        }
    }
}