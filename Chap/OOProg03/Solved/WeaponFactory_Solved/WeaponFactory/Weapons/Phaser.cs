namespace WeaponFactory.Weapons
{
    public class Phaser : WeaponBase
    {
        public override string Description
        {
            get { return "Starfleet Phaser 2287"; }
        }

        public override int Damage
        {
            get { return 150; }
        }
    }
}