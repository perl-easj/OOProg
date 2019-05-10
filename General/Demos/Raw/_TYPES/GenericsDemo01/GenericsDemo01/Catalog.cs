using System.Collections.Generic;

namespace GenericsDemo01
{
    public class Catalog<TData, T, TKey> : ICreate<TData>, IDelete<TKey>
        where T : IKey<TKey>
    {
        private Dictionary<TKey, T> _data;
        private IFactory<T, TData> _factory;

        public Catalog(IFactory<T, TData> factory)
        {
            _data = new Dictionary<TKey, T>();
            _factory = factory;
        }

        public void Create(TData data)
        {
            T obj = _factory.Convert(data);
            _data.Add(obj.Key, obj);
        }

        public void Delete(TKey key)
        {
            _data.Remove(key);
        }
    }
}