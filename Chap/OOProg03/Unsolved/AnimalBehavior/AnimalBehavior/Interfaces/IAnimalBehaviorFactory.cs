namespace AnimalBehavior.Interfaces
{
    /// <summary>
    /// Calling any of the three methods in the interface
    /// should return an object implementing IAnimalBehavior.
    /// The specific implementation is expected to somehow
    /// reflect the specific method called. That is, we do
    /// expect that the object returned when calling e.g.
    /// CreateFearfulBehavior does implement a "fearful" behavior.
    /// </summary>
    public interface IAnimalBehaviorFactory
    {
        IAnimalBehavior CreateAggressiveBehavior();
        IAnimalBehavior CreateFearfulBehavior();
        IAnimalBehavior CreateIdleBehavior();
    }
}