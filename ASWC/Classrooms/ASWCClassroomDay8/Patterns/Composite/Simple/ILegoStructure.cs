namespace Patterns.Composite.Simple
{
    public interface ILegoStructure
    {
        double TotalWeight { get; }
        int noOfBlocks { get; }
        string Description { get; }
    }
}