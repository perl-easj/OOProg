namespace SOLID.Liskov.Composition
{
    public class AnimalHuntedByImpl : IAnimalHuntedBy
    {
        public AnimalHuntedByImpl(IAnimal animal = null)
        {
            IsHuntedBy = animal;
        }

        public IAnimal IsHuntedBy { get; set; }
    }
}