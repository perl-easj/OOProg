namespace FOOrrestGump.Interfaces
{
    /// <summary>
    /// Minimal interface for representing a container.
    /// </summary>
    /// <typeparam name="T">Type of items stored in container.</typeparam>
    public interface IContainer<out T>
    {
        bool Empty { get; }
        T TakeNext();
    }
}