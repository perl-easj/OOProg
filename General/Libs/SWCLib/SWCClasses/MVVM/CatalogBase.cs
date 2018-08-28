using System.Collections.Generic;
using SWCClasses.DataStructures;
// ReSharper disable StaticMemberInGenericType

namespace SWCClasses.MVVM
{
    public abstract class CatalogBase<T>
    {
        /// <summary>
        /// Keep track of keys for objects
        /// </summary>
        private static int _keyCount = 1;

        /// <summary>
        /// Uses a Generic Catalog to store domain objects,
        /// so they can be looked up using a key value
        /// </summary>
        private GenericCatalog<int, T> _catalog;

        protected CatalogBase()
        {
            _catalog = new GenericCatalog<int, T>();
        }

        public int Count
        {
            get { return _catalog.Count; }
        }

        public List<T> All
        {
            get { return _catalog.All; }
        }

        public void Create(T val)
        {
            _catalog.Insert(_keyCount++, val);
        }

        public T Read(int key)
        {
            return _catalog.Read(key);
        }

        public void Update(int key, T val)
        {
            _catalog.Update(key, val);
        }

        public void Delete(int key)
        {
            _catalog.Delete(key);
        }
    }
}