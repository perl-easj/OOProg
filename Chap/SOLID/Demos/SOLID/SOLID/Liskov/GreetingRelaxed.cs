namespace SOLID.Liskov
{
    public class GreetingRelaxed : GreetingBase
    {
        protected override void HandleShortName(string name)
        {
            SayHelloUnconditional(name);
        }
    }
}