namespace FOOrrestGump.Interfaces
{
    /// <summary>
    /// Any class representing an entity capable of "consuming"
    /// should implement this interface.
    /// </summary>
    public interface IConsumer<in T> where T : IConsumable
    {
        void PreConsumeAction();
        void Consume(T aConsumable);
        void PostConsumeAction();
    }
}