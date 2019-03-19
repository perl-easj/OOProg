using System;

namespace SOLID.Liskov.Greeting
{
    public abstract class GreetingBase : ICheckedGreeting
    {
        public void SayHello(string name)
        {
            if (name.Length < 3)
            {
                HandleShortName(name);
            }
            else
            {
                SayHelloUnconditional(name);
            }
        }

        protected virtual void SayHelloUnconditional(string name)
        {
            Console.WriteLine($"Hello {name}");
        }

        protected abstract void HandleShortName(string name);
    }
}