namespace SOLID.Liskov.Composition
{
    public class Cat : Animal
    {
        public Cat(double weight) : base( 
            new AnimalHuntedByImpl(new Dog(25)), 
            new AnimalWeightNormalImpl(weight))
        {
        }
    }
}