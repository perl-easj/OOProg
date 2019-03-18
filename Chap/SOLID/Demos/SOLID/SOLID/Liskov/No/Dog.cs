namespace SOLID.Liskov.No
{
    public class Dog : Animal
    {
        public Dog(double weightInKg) 
            : base("Dog", weightInKg)
        {
        }
    }
}