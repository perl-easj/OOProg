namespace SOLID.Liskov.Yes
{
    public class Dog : AnimalSizeLarge, IHuntedAnimal
    {
        public Dog(IAnimal hunter = null) 
            : base("Dog")
        {
            IsHuntedBy = hunter;
        }

        public IAnimal IsHuntedBy { get; set; }
    }
}