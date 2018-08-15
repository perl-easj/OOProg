using WesternStrike.Weapons.Base;

namespace WesternStrike.Weapons.Types.Bows
{
    public class Bow : Weapon
    {
        public const string Junior = "Junior";
        public const string Long = "Long";
        public const string Striker = "Striker";

        public Bow(string id, int baseDamage, int maxAdditionalDamage) 
            : base(WeaponType.Bow, id, baseDamage, maxAdditionalDamage)
        {
        }
    }
}