namespace SOLID.Liskov.Composition
{
    public class Tiger : Animal
    {
        public Tiger(double weight) : base(
            new AnimalHuntedByExceptionImpl(), 
            new AnimalWeightLargeImpl(weight))
        {
        }
    }
}