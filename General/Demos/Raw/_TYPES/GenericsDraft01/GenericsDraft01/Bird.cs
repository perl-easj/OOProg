using System;

namespace GenericsDraft01
{
    public class Bird : Animal
    {
        public Bird(string name) : base(name, 1)
        {
        }

        public void FlapWings()
        {
            Console.WriteLine("*Bird flaps wings...");
        }

        public override string Sound()
        {
            return "Tweet";
        }
    }
}