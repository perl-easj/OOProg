namespace GenericsDemo01
{
    public interface IKey<TKey>
    {
        TKey Key { get; }
    }
}