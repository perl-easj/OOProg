namespace NaiveRPG.Interfaces
{
    /// <summary>
    /// Minimal interface for items.
    /// All items have a description.
    /// </summary>
    public interface IItem
    {
        string Description { get; }
    }
}