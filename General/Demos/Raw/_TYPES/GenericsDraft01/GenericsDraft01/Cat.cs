using System;

namespace GenericsDraft01
{
    public class Cat : Animal
    {
        public Cat(string name, double weight) : base(name, weight)
        {
        }

        public void Purr()
        {
            Console.WriteLine("*Cat purrs...");
        }

        public override string Sound()
        {
            return "Meow";
        }
    }
}