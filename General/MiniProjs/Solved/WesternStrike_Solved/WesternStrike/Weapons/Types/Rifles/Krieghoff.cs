namespace WesternStrike.Weapons.Types.Rifles
{
    public class Krieghoff : Rifle
    {
        public Krieghoff(bool isScoped = false) : base(Rifle.Krieghoff,
            WeaponsDB.Data.BaseDamage(Rifle.Krieghoff),
            WeaponsDB.Data.MaxAdditionalDamage(Rifle.Krieghoff),
            isScoped)
        {
        }
    }
}