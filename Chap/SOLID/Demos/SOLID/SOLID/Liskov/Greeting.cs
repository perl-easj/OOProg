using System;

namespace SOLID.Liskov
{
    public class Greeting : IGreeting
    {
        public void SayHello(Name name)
        {
            Console.WriteLine($"Hello {name.Value}");
        }
    }
}