namespace WesternStrike.Weapons.Types.Bows
{
    public class JuniorBow : Bow
    {
        public JuniorBow() : base(Bow.Junior,
            WeaponsDB.Data.BaseDamage(Bow.Junior),
            WeaponsDB.Data.MaxAdditionalDamage(Bow.Junior))
        {
        }
    }
}