using NaiveRPG.Interfaces;

namespace NaiveRPG.Items.Armor
{
    public class PlateBoots : ArmorBase
    {
        public override string Name
        {
            get { return "Hardened Plate Boots"; }
        }

        public override int MaxArmorPoints
        {
            get { return 65; }
        }
    }
}