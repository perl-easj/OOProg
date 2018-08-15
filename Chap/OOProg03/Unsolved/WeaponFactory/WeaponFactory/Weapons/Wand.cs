namespace WeaponFactory.Weapons
{
    public class Wand : WeaponBase
    {
        public override string Description
        {
            get { return "Dragonhair Wand"; }
        }

        public override int Damage
        {
            get { return 250; }
        }
    }
}