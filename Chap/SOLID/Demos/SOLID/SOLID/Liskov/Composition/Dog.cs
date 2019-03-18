namespace SOLID.Liskov.Composition
{
    public class Dog : Animal
    {
        public Dog(double weight) : base(
            new AnimalHuntedByImpl(), 
            new AnimalWeightLargeImpl(weight))
        {
        }
    }
}