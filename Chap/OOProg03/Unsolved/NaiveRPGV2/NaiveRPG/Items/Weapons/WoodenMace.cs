namespace NaiveRPG.Items.Weapons
{
    public class WoodenMace : WeaponBase
    {
        public WoodenMace() : base(30)
        {
        }

        public override string Description
        {
            get { return "Rough Wooden Mace"; }
        }
    }
}