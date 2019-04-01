namespace Patterns.Composite.Simple
{
    public class LegoBlock : ILegoStructure
    {
        public string Description { get; }
        public double TotalWeight { get; }

        public LegoBlock(double weight, string description)
        {
            TotalWeight = weight;
            Description = description;
        }
    
        public int noOfBlocks { get { return 1; } }
    }
}