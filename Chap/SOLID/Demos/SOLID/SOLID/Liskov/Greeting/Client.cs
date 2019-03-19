using System;
using System.Collections.Generic;

namespace SOLID.Liskov.Greeting
{
    public class Client
    {
        public void Run()
        {
            DoSomething(new GreetingRelaxed()); // OK
            DoSomething(new GreetingStrict()); // OK
        }

        public void DoSomething(ICheckedGreeting obj)
        {
            List<string> names = new List<string>
            {
                "Alex, ", "Betty", "Bo"
            };

            foreach (string name in names)
            {
                try
                {
                    obj.SayHello(name);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception when " +
                        $"calling SayHello: {e.Message}");
                }
            }
        }
    }
}