using WesternStrike.Weapons.Base;

namespace WesternStrike.Weapons.Types.Guns
{
    public class Gun : Weapon
    {
        public const string Colt = "Colt";
        public const string Ruger = "Ruger";
        public const string SmithWesson = "SmithWesson";

        public Gun(string id, int baseDamage, int maxAdditionalDamage) 
            : base(WeaponType.Gun, id, baseDamage, maxAdditionalDamage)
        {
        }
    }
}