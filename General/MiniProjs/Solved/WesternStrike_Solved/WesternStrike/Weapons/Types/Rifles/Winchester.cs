namespace WesternStrike.Weapons.Types.Rifles
{
    public class Winchester : Rifle
    {
        public Winchester(bool isScoped = false) : base(Rifle.Winchester,
            WeaponsDB.Data.BaseDamage(Rifle.Winchester),
            WeaponsDB.Data.MaxAdditionalDamage(Rifle.Winchester),
            isScoped)
        {
        }
    }
}