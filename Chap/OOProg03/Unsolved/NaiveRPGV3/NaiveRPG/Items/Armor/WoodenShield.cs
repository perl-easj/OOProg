using NaiveRPG.Interfaces;

namespace NaiveRPG.Items.Armor
{
    public class WoodenShield : ArmorBase
    {
        public override string Name
        {
            get { return "Round Wooden Shield"; }
        }

        public override int MaxArmorPoints
        {
            get { return 40; }
        }
    }
}