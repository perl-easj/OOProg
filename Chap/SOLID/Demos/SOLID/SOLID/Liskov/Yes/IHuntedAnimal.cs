namespace SOLID.Liskov.Yes
{
    public interface IHuntedAnimal
    {
        IAnimal IsHuntedBy { get; set; }
    }
}