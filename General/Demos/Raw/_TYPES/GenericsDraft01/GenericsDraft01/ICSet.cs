namespace GenericsDraft01
{
    public interface ICSet<in T>
    {
        void Set(T t);
    }
}