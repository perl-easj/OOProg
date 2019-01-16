using System;
using System.Collections.Generic;
using ImprovedCatalog.CatalogBaseClasses.Interfaces;

namespace ImprovedCatalog.CatalogBaseClasses.Catalogs
{
    /// <summary>
    /// Class implementing a bare-bones version of a catalog. More specifically,
    /// the class implements the interfaces IAll and ICatalog.
    /// The implementation allows the creator of a Catalog to opt for loading
    /// of test data upon creation.
    /// </summary>
    /// <typeparam name="K">Type for key for values stored in catalog</typeparam>
    /// <typeparam name="V">Type for values stored in catalog</typeparam>
    public class Catalog<K, V> : IAll<V>, ICatalog<K, V>
    {
        #region Constructor and Instance Fields
        private Dictionary<K, V> _objects;

        public Catalog(bool loadTestData = false)
        {
            _objects = new Dictionary<K, V>();

            if (loadTestData) LoadTestData();
        }
        #endregion

        #region Implementation of IAll
        /// <inheritdoc />
        public IEnumerable<V> All
        {
            get { return _objects.Values; }
        }
        #endregion

        #region Implementation of ICatalog
        /// <inheritdoc />
        public V Read(K key)
        {
            return _objects.ContainsKey(key) ? _objects[key] : default(V);
        }

        /// <inheritdoc />
        /// Note that handling of key-already-exists is delegated
        /// to the (virtual) method InsertKeyAlreadyExistsHandler.
        public void Insert(K key, V value)
        {
            if (!_objects.ContainsKey(key))
            {
                _objects.Add(key, value);
            }
            else
            {
                InsertKeyAlreadyExistsHandler(key);
            }
        }

        /// <inheritdoc />
        public void Delete(K key)
        {
            _objects.Remove(key);
        }
        #endregion

        #region Helper methods (virtual)
        /// <summary>
        /// This method should be overrided in derived classes,
        /// where specific test data can be defined.
        /// </summary>
        protected virtual void LoadTestData()
        {
            throw new ArgumentException("LoadTestData should only be called if it has been overrided.");
        }

        /// <summary>
        /// Default handling of key-already-exists error scenario.
        /// </summary>
        protected virtual void InsertKeyAlreadyExistsHandler(K key)
        {
            throw new ArgumentException($"Item with key {key} already in Catalog");
        } 
        #endregion
    }
}