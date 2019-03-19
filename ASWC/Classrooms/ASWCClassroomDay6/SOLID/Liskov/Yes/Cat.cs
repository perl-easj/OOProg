namespace SOLID.Liskov.Yes
{
    public class Cat : AnimalSizeNormal, IHuntedAnimal
    {
        public Cat(IAnimal hunter = null) 
            : base("Cat")
        {
            IsHuntedBy = hunter;
        }

        public IAnimal IsHuntedBy { get; set; }
    }
}