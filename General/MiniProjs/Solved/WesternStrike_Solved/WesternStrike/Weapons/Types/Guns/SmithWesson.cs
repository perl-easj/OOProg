namespace WesternStrike.Weapons.Types.Guns
{
    public class SmithWesson : Gun
    {
        public SmithWesson() : base(Gun.SmithWesson,
            WeaponsDB.Data.BaseDamage(Gun.SmithWesson),
            WeaponsDB.Data.MaxAdditionalDamage(Gun.SmithWesson))
        {
        }
    }
}