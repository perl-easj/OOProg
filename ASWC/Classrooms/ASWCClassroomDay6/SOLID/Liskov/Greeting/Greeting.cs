using System;

namespace SOLID.Liskov.Greeting
{
    public class Greeting : IGreeting
    {
        public void SayHello(Name name)
        {
            Console.WriteLine($"Hello {name.Value}");
        }
    }
}