namespace NaiveRPG
{
    public class WeaponBase : ItemBase
    {
        public WeaponBase(string description, int valueInGold) 
            : base(description, valueInGold, ItemCategory.weapon)
        {
        }
    }
}