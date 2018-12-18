using System.Collections.Generic;
using System.Linq;
using Data.InMemory.Interfaces;

namespace Data.InMemory.Implementation
{
    /// <summary>
    /// Implementation of the interface for an in-memory 
    /// collection, typically of domain objects
    /// </summary>
    /// <typeparam name="T">
    /// Type of stored objects. Type must inherit from IStorable.
    /// </typeparam>
    public class InMemoryCollection<T> : IInMemoryCollection<T>
        where T : class, IStorable
    {
        private Dictionary<int, T> _collection;

        public InMemoryCollection()
        {
            _collection = new Dictionary<int, T>();
        }

        /// <inheritdoc />
        public List<T> All
        {
            get { return _collection.Values.ToList(); }
        }

        /// <inheritdoc />
        public int Insert(T obj, KeyManagementStrategyType keyManagement = KeyManagementStrategyType.CollectionDecides)
        {
            if (keyManagement == KeyManagementStrategyType.CollectionDecides)
            {
                obj.Key = NextKey();
            }
            _collection.Add(obj.Key, obj);

            return obj.Key;
        }

        /// <inheritdoc />
        public T Get(int key)
        {
            return _collection.ContainsKey(key) ? _collection[key] : null;
        }

        /// <inheritdoc />
        public T this[int key]
        {
            get { return Get(key); }
        }

        /// <inheritdoc />
        public void Remove(int key)
        {
            _collection.Remove(key);
        }

        /// <inheritdoc />
        public void Replace(int key, T obj)
        {
            obj.Key = key;
            _collection[key] = obj;
        }

        /// <inheritdoc />
        public void InsertAll(List<T> objects, KeyManagementStrategyType keyManagement = KeyManagementStrategyType.CollectionDecides)
        {
            foreach (var obj in objects)
            {
                Insert(obj, keyManagement);
            }
        }

        /// <inheritdoc />
        public void ReplaceAll(List<T> objects, KeyManagementStrategyType keyManagement = KeyManagementStrategyType.CollectionDecides)
        {
            RemoveAll();
            foreach (var obj in objects)
            {
                Insert(obj, keyManagement);
            }
        }

        /// <inheritdoc />
        public void RemoveAll()
        {
            _collection.Clear();
        }

        /// <summary>
        /// Finds the next valid key for a new object to be inserted
        /// into the collection.
        /// </summary>
        /// <returns>
        /// Key to assign to new object.
        /// </returns>
        private int NextKey()
        {
            return ((_collection.Count == 0) ? 0 : _collection.Keys.Max() + 1);
        }
    }
}