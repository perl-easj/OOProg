namespace GenericsDemo01
{
    public interface ICreate<TData>
    {
        void Create(TData obj);
    }
}