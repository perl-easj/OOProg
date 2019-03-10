using FOOrrestGump.Interfaces;

namespace FOOrrestGump.Adapters.Interfaces
{
    /// <summary>
    /// Interface for any class adapting the adaptee to the IConsumer interface.
    /// Such a class must implement the IAdapter interface AND the IConsumer interface.
    /// </summary>
    /// <typeparam name="T">Type of item being consumed by the consumer being adapted to IConsumer</typeparam>
    /// <typeparam name="TConsumer">Type of consumer being adapted to IConsumer.</typeparam>
    public interface IConsumerAdapter<in T, out TConsumer> :  IAdapter<TConsumer>, IConsumer<T> 
        where T : IConsumable
    {       
    }
}