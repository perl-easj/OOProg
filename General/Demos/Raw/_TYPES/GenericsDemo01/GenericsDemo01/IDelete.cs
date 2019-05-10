namespace GenericsDemo01
{
    public interface IDelete<TKey>
    {
        void Delete(TKey key);
    }
}