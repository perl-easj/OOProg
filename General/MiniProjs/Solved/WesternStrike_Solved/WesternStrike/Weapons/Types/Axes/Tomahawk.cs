namespace WesternStrike.Weapons.Types.Axes
{
    public class Tomahawk : Axe
    {
        public Tomahawk() : base(Axe.Tomahawk,
            WeaponsDB.Data.BaseDamage(Axe.Tomahawk),
            WeaponsDB.Data.MaxAdditionalDamage(Axe.Tomahawk))
        {
        }
    }
}