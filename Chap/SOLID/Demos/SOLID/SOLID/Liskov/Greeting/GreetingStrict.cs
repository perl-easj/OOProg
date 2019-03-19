using System;

namespace SOLID.Liskov.Greeting
{
    public class GreetingStrict : GreetingBase
    {
        protected override void HandleShortName(string name)
        {
            throw new ArgumentException("Name too short!");
        }
    }
}