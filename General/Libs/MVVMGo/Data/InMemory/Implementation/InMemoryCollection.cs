using System.Collections.Generic;
using System.Linq;
using Data.InMemory.Interfaces;

namespace Data.InMemory.Implementation
{
    /// <summary>
    /// Implementation of the interface for an in-memory 
    /// collection, typically of domain objects
    /// </summary>
    /// <typeparam name="TDomainData">
    /// Type of stored objects. Type must inherit from IStorable.
    /// </typeparam>
    public class InMemoryCollection<TDomainData> : IInMemoryCollection<TDomainData>
        where TDomainData : class, IStorable
    {
        private Dictionary<int, TDomainData> _collection;

        public InMemoryCollection()
        {
            _collection = new Dictionary<int, TDomainData>();
        }

        /// <inheritdoc />
        public List<TDomainData> All
        {
            get { return _collection.Values.ToList(); }
        }

        /// <inheritdoc />
        public int Insert(TDomainData obj, KeyManagementStrategyType keyManagement = KeyManagementStrategyType.CollectionDecides)
        {
            if (keyManagement == KeyManagementStrategyType.CollectionDecides)
            {
                obj.Key = NextKey();
            }
            _collection.Add(obj.Key, obj);

            return obj.Key;
        }

        /// <inheritdoc />
        public TDomainData Get(int key)
        {
            return _collection.ContainsKey(key) ? _collection[key] : null;
        }

        /// <inheritdoc />
        public TDomainData this[int key]
        {
            get { return Get(key); }
        }

        /// <inheritdoc />
        public void Remove(int key)
        {
            _collection.Remove(key);
        }

        /// <inheritdoc />
        public void InsertAll(List<TDomainData> objects, KeyManagementStrategyType keyManagement = KeyManagementStrategyType.CollectionDecides)
        {
            foreach (var obj in objects)
            {
                Insert(obj, keyManagement);
            }
        }

        /// <inheritdoc />
        public void ReplaceAll(List<TDomainData> objects, KeyManagementStrategyType keyManagement = KeyManagementStrategyType.CollectionDecides)
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