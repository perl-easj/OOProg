namespace NaiveRPG.Items.Weapons
{
    public class SteelLance : WeaponBase
    {
        public SteelLance() : base(75)
        {
        }

        public override string Description
        {
            get { return "Sharpened Steel Lance"; }
        }
    }
}