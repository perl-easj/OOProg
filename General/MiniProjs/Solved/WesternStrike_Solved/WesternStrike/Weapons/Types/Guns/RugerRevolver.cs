namespace WesternStrike.Weapons.Types.Guns
{
    public class RugerRevolver : Gun
    {
        public RugerRevolver() : base(Gun.Ruger,
            WeaponsDB.Data.BaseDamage(Gun.Ruger),
            WeaponsDB.Data.MaxAdditionalDamage(Gun.Ruger))
        {
        }
    }
}