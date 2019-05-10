namespace GenericsDraft01
{
    public interface ICGet<out T>
    {
        T Get();
    }
}