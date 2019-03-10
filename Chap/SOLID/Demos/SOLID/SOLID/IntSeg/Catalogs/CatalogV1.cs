using System.Collections.Generic;
using SOLID.IntSeg.Interfaces;

namespace SOLID.IntSeg.Catalogs
{
    /// <summary>
    /// Classic implementation of a Catalog.
    /// NB: Implements the full ICreateReadUpdateDelete interface
    /// </summary>
    public class CatalogV1<T> : ICreateReadUpdateDelete<T>
    {
        private Dictionary<int, T> _objects;

        public CatalogV1()
        {
            _objects = new Dictionary<int, T>();
        }

        public void Create(int key, T obj)
        {
            if (!_objects.ContainsKey(key))
            {
                _objects.Add(key, obj);
            }
        }

        public T Read(int key)
        {
            return _objects.ContainsKey(key) ? _objects[key] : default(T);
        }

        public void Update(int key, T obj)
        {
            if (_objects.ContainsKey(key))
            {
                _objects[key] = obj;
            }
        }

        public void Delete(int key)
        {
            _objects.Remove(key);
        }
    }
}