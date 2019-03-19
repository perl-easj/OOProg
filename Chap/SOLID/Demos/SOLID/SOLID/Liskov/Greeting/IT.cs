namespace SOLID.Liskov.Greeting
{
    public interface IT
    {
        /// <summary>
        /// Contract: Invoking this method should print a message on the screen.
        /// </summary>
        void SayHello(string name);
    }
}