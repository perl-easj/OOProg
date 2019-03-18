namespace SOLID.Liskov.Yes
{
    /// <summary>
    /// Any object implementing this interface cannot
    /// represent an animal with weight lower than 0.001 kg.
    /// </summary>
    public interface INormalSizeAnimal
    {
        double WeightInKg { get; set; }
        void ValidateNormalWeight(double weight);
    }
}