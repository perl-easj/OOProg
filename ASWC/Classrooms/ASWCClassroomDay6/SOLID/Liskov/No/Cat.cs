using System;

namespace SOLID.Liskov.No
{
    public class Cat : Animal
    {
        public Cat(double weightInKg, Animal isHuntedBy = null) 
            : base("Cat", weightInKg, isHuntedBy)
        {
        }

        public void Purr()
        {
            Console.WriteLine("(Cat purrs...)");
        }
    }
}