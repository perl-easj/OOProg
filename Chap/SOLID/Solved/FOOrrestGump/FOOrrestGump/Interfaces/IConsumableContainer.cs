namespace FOOrrestGump.Interfaces
{
    /// <summary>
    /// A "consumable container" is simply a container containing
    /// consumable items.
    /// </summary>
    /// <typeparam name="T">Type of items stored in container.</typeparam>
    public interface IConsumableContainer<out T> : IContainer<T> 
        where T : IConsumable
    {
        
    }
}