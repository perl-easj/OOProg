namespace NaiveRPG
{
    public class ItemBase : IItem
    {
        public string Description { get; }
        public int ValueInGold { get; }
        public ItemCategory Category { get; }

        public ItemBase(string description, int valueInGold, ItemCategory category)
        {
            Description = description;
            ValueInGold = valueInGold;
            Category = category;
        }

        public override string ToString()
        {
            return $"{Description} {this.GetType().Name}, is worth {ValueInGold} gold";
        }
    }
}