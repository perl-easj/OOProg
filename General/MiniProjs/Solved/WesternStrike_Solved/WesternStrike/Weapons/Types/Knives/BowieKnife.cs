namespace WesternStrike.Weapons.Types.Knives
{
    public class BowieKnife : Knife
    {
        public BowieKnife() : base(Knife.Bowie,
            WeaponsDB.Data.BaseDamage(Knife.Bowie),
            WeaponsDB.Data.MaxAdditionalDamage(Knife.Bowie))
        {
        }
    }
}