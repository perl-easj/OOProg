using WesternStrike.Weapons.Base;

namespace WesternStrike.Weapons.Types.Knives
{
    public class Knife : Weapon
    {
        public const string Bowie = "Bowie";
        public const string Dundee = "Dundee";
        public const string Gutter = "Gutter";

        public Knife(string id, int baseDamage, int maxAdditionalDamage) 
            : base(WeaponType.Knife, id, baseDamage, maxAdditionalDamage)
        {
        }
    }
}