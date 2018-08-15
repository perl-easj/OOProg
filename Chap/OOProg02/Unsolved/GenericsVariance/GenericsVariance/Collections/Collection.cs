using System.Collections.Generic;

namespace GenericsVariance.Collections
{
    public class Collection<T> : ICollectionGet<T>, ICollectionSet<T>
    {
        private List<T> _collection;

        public Collection()
        {
            _collection = new List<T>();
        }

        public int Count
        {
            get { return _collection.Count; }
        }

        public T Get(int index)
        {
            return _collection[index];
        }

        public int Set(T obj)
        {
            _collection.Add(obj);
            return (_collection.Count - 1);
        }
    }
}