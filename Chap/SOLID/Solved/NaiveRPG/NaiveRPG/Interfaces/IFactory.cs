namespace NaiveRPG.Factories
{
    public interface IFactory<out T>
    {
        T Create();
    }
}