namespace WesternStrike.Weapons.Types.Axes
{
    public class DoubleAxe : Axe
    {
        public DoubleAxe() : base(Axe.DoubleAxe,
            WeaponsDB.Data.BaseDamage(Axe.DoubleAxe),
            WeaponsDB.Data.MaxAdditionalDamage(Axe.DoubleAxe))
        {
        }
    }
}