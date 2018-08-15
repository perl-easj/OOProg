using WesternStrike.Weapons.Base;

namespace WesternStrike.Weapons.Types.Axes
{
    public class Axe : Weapon
    {
        public const string Damascus = "Damascus";
        public const string DoubleAxe = "DoubleAxe";
        public const string Tomahawk = "Tomahawk";

        public Axe(string id, int baseDamage, int maxAdditionalDamage) 
            : base(WeaponType.Axe, id, baseDamage, maxAdditionalDamage)
        {
        }
    }
}