namespace WesternStrike.Weapons.Types.Axes
{
    public class Damascus : Axe
    {
        public Damascus() : base(Axe.Damascus, 
            WeaponsDB.Data.BaseDamage(Axe.Damascus),
            WeaponsDB.Data.MaxAdditionalDamage(Axe.Damascus))
        {
        }
    }
}