using FOOrrestGump.Interfaces;

namespace FOOrrestGump.Adapters.Interfaces
{
    /// <summary>
    /// Interface for any class adapting a container to the IConsumableContainer interface.
    /// Such a class must implement the IAdapter interface AND the IConsumableContainer interface.
    /// </summary>
    /// <typeparam name="T">Type of item contained in the adapted container.</typeparam>
    /// <typeparam name="TContainer">Type of container being adapted to IConsumableContainer.</typeparam>
    public interface IConsumableContainerAdapter<out T, out TContainer> : IAdapter<TContainer>, IConsumableContainer<T> 
        where T : IConsumable
    {       
    }
}