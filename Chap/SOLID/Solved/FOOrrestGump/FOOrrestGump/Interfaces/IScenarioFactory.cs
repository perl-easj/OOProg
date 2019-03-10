namespace FOOrrestGump.Interfaces
{
    /// <summary>
    /// Interface for a Factory producing a "scenario", defined as
    /// consisting of a Consumer and a Consumable Container.
    /// </summary>
    /// <typeparam name="T">Type of items being consumed.</typeparam>
    public interface IScenarioFactory<T> where T : IConsumable
    {
        IConsumer<T> CreateConsumer();
        IConsumableContainer<T> CreateContainer();
    }
}