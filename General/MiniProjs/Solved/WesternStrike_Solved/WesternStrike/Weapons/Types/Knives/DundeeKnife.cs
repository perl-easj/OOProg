namespace WesternStrike.Weapons.Types.Knives
{
    public class DundeeKnife : Knife
    {
        public DundeeKnife() : base(Knife.Dundee,
            WeaponsDB.Data.BaseDamage(Knife.Dundee),
            WeaponsDB.Data.MaxAdditionalDamage(Knife.Dundee))
        {
        }
    }
}