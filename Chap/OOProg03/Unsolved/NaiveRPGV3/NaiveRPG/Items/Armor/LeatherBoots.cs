using NaiveRPG.Interfaces;

namespace NaiveRPG.Items.Armor
{
    public class LeatherBoots : ArmorBase
    {
        public override string Name
        {
            get { return "Brown Leather Boots "; }
        }

        public override int MaxArmorPoints
        {
            get { return 25; }
        }
    }
}