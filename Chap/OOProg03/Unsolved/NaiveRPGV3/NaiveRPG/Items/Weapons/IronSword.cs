namespace NaiveRPG.Items.Weapons
{
    public class IronSword : WeaponBase
    {
        public override string Name
        {
            get { return "One-Handed Iron Sword "; }
        }

        public override int MaxMaxWeaponDamage
        {
            get { return 40; }
        }
    }
}