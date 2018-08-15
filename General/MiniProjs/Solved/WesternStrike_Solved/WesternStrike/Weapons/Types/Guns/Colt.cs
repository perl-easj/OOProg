namespace WesternStrike.Weapons.Types.Guns
{
    public class Colt : Gun
    {
        public Colt() : base(Gun.Colt,
            WeaponsDB.Data.BaseDamage(Gun.Colt),
            WeaponsDB.Data.MaxAdditionalDamage(Gun.Colt))
        {
        }
    }
}