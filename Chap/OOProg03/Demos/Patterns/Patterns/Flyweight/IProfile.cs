namespace Patterns.Flyweight
{
    public interface IProfile
    {
        string UserName { get; }
        int[] ImageData { get; }
        void Display();
    }
}