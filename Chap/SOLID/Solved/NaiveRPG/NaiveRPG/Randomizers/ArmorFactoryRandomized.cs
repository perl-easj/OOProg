using System;

namespace NaiveRPG.Factories
{
    public class ArmorFactoryRandomized : RandomizedFactory<IItem>
    {
        private ColorFactoryRandomized _colorFac;
        private DescriptionFactoryRandomized _descFac;
        private GoldValueFactoryRandomized _goldFac;

        public ArmorFactoryRandomized()
        {
            _colorFac = new ColorFactoryRandomized();
            _descFac = new DescriptionFactoryRandomized();
            _goldFac = new GoldValueFactoryRandomized(200);

            AddFactoryMethod(50, CreateBoots);
            AddFactoryMethod(50, CreateChest);
        }

        // Could later on generate "subclasses" of Boots
        private Boots CreateBoots()
        {
            string desc = "A " + _descFac.Create() + " pair of " + _colorFac.Create() + " boots";
            return new Boots(desc, _goldFac.Create());
        }

        // Could later on generate "subclasses" of Chest
        private Chest CreateChest()
        {
            string desc = "A " + _descFac.Create() + ", " + _colorFac.Create() + " chest piece";
            return new Chest(desc, _goldFac.Create());
        }
    }
}