using System;

namespace SOLID.Liskov.Greeting
{
    public class CheckedGreeting : ICheckedGreeting
    {
        public void SayHello(string name)
        {
            if (name.Length < 3)
            {
                throw new ArgumentException("Name too short!");
            }

            Console.WriteLine($"Hello {name}");
        }
    }
}