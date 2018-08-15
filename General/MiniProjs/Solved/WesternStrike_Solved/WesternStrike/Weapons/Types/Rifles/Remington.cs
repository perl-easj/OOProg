namespace WesternStrike.Weapons.Types.Rifles
{
    public class Remington : Rifle
    {
        public Remington() : base(Rifle.Remington,
            WeaponsDB.Data.BaseDamage(Rifle.Remington),
            WeaponsDB.Data.MaxAdditionalDamage(Rifle.Remington))
        {
        }
    }
}