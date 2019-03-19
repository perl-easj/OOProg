namespace SOLID.Liskov.Yes
{
    /// <summary>
    /// Any object implementing this interface cannot
    /// represent an animal with weight lower than 1.0 kg.
    /// </summary>
    public interface ILargeSizeAnimal
    {
        double WeightInKg { get; set; }
        void ValidateLargeWeight(double weight);
    }
}