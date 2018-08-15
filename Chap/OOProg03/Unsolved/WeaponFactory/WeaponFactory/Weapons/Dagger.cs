namespace WeaponFactory.Weapons
{
    public class Dagger : WeaponBase
    {
        public override string Description
        {
            get { return "Steel Dagger"; }
        }

        public override int Damage
        {
            get { return 30; }
        }
    }
}