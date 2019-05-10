namespace GenericsDraft01
{
    public interface ICollectionGet<out T>
    {
        T Get(int index);
        int Count { get; }
    }
}