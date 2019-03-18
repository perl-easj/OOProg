namespace NaiveRPG
{
    public class Boots : ArmorBase
    {
        public Boots(string description, int valueInGold) 
            : base(description, valueInGold, ArmorSlot.feet)
        {
        }
    }
}