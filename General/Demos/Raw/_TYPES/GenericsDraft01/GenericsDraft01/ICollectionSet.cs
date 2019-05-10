namespace GenericsDraft01
{
    public interface ICollectionSet<in T>
    {
        int Set(T obj);
    }
}