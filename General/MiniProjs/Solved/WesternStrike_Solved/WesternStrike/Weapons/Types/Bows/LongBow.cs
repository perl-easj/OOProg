namespace WesternStrike.Weapons.Types.Bows
{
    public class LongBow : Bow
    {
        public LongBow() : base(Bow.Long,
            WeaponsDB.Data.BaseDamage(Bow.Long),
            WeaponsDB.Data.MaxAdditionalDamage(Bow.Long))
        {
        }
    }
}