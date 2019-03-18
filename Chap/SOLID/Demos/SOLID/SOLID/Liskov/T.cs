using System;

namespace SOLID.Liskov
{
    public class T : IT
    {
        public virtual void SayHello(string name)
        {
            Console.WriteLine($"Hello {name}");
        }
    }
}