namespace WesternStrike.Weapons.Types.Bows
{
    public class StrikerBow : Bow
    {
        public StrikerBow() : base(Bow.Striker,
            WeaponsDB.Data.BaseDamage(Bow.Striker),
            WeaponsDB.Data.MaxAdditionalDamage(Bow.Striker))
        {
        }
    }
}