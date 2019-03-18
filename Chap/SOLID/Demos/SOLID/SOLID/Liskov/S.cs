using System;

namespace SOLID.Liskov
{
    public class S : T
    {
        public override void SayHello(string name)
        {
            Console.WriteLine($"Hola {name}");
        }
    }
}