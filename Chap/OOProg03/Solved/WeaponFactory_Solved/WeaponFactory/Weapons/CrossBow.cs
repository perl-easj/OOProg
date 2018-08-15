namespace WeaponFactory.Weapons
{
    public class CrossBow : WeaponBase
    {
        public override string Description
        {
            get { return "Iron-plated Crossbow"; }
        }

        public override int Damage
        {
            get { return 70; }
        }
    }
}