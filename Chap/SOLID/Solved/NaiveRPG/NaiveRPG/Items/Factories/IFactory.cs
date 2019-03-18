namespace NaiveRPG.Factories
{
    public interface IFactory<T>
    {
        T Create();
    }
}