namespace SOLID.Liskov.Composition
{
    public interface IAnimalHuntedBy
    {
        IAnimal IsHuntedBy { get; set; }
    }
}