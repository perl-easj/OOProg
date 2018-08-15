using WesternStrike.Weapons.Base;

namespace WesternStrike.Weapons.Types.Rifles
{
    public class Rifle : Weapon
    {
        public const string Krieghoff = "Krieghoff";
        public const string Remington = "Remington";
        public const string Winchester = "Winchester";

        private bool _isScoped;

        public Rifle(string id, int baseDamage, int maxAdditionalDamage, bool isScoped = false)
            : base(WeaponType.Rifle, id, baseDamage, maxAdditionalDamage)
        {
            _isScoped = isScoped;
        }

        public override int EnhancementDamage
        {
            get { return _isScoped ? BaseDamage / 4 : 0; }
        }
    }
}