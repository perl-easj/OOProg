using FOOrrestGump.Interfaces;

namespace FOOrrestGump.Adapters.Interfaces
{
    /// <summary>
    /// Interface for any class adapting the adaptee to the IConsumable interface.
    /// Such a class must implement the IAdapter interface AND the IConsumable interface.
    /// </summary>
    /// <typeparam name="T">Type of item being adapted to IConsumable</typeparam>
    public interface IConsumableAdapter<out T> : IAdapter<T>, IConsumable
    {
    }
}