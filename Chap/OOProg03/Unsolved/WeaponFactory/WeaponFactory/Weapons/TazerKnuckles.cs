namespace WeaponFactory.Weapons
{
    public class TazerKnuckles : WeaponBase
    {
        public override string Description
        {
            get { return "TazerKnuckles 50kV"; }
        }

        public override int Damage
        {
            get { return 50; }
        }
    }
}