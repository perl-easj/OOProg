namespace SOLID.Liskov.Composition
{
    public interface IAnimal
    {
        string Description { get; }
        double WeightInKg { get; set; }
        IAnimal IsHuntedBy { get; set; }
    }
}