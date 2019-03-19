namespace SOLID.Liskov.Greeting
{
    public interface ICheckedGreeting
    {
        /// <summary>
        /// Contract: Invoking this method with names longer than two
        /// characters should print a message on the screen.
        /// In case of being invoked with a name at most two characters
        /// long, the method may throw an ArgumentException
        /// </summary>
        void SayHello(string name);
    }
}