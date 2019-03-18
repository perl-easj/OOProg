namespace NaiveRPG
{
    public class Chest : ArmorBase
    {
        public Chest(string description, int valueInGold) 
            : base(description, valueInGold, ArmorSlot.chest)
        {
        }
    }
}