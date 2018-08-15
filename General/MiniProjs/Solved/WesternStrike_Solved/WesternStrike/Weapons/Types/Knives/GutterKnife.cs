namespace WesternStrike.Weapons.Types.Knives
{
    public class GutterKnife : Knife
    {
        public GutterKnife() : base(Knife.Gutter,
            WeaponsDB.Data.BaseDamage(Knife.Gutter),
            WeaponsDB.Data.MaxAdditionalDamage(Knife.Gutter))
        {
        }
    }
}