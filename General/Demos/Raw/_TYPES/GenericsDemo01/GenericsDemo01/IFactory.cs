namespace GenericsDemo01
{
    public interface IFactory<T, TData>
    {
        T Convert(TData obj);
    }
}