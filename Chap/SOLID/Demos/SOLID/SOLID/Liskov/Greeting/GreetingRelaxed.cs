namespace SOLID.Liskov.Greeting
{
    public class GreetingRelaxed : GreetingBase
    {
        protected override void HandleShortName(string name)
        {
            SayHelloUnconditional(name);
        }
    }
}