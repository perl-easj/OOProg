using System.Collections.Generic;
using SOLID.IntSeg.Interfaces;

namespace SOLID.IntSeg.Catalogs
{
    /// <summary>
    /// Classic implementation of a Catalog.
    /// Logic is identical to CatalogV1.
    /// NB: Implements the four "segregated interfaces.
    /// </summary>
    public class CatalogV2<T> : ICreate<T>, IRead<T>, IUpdate<T>, IDelete<T>
    {
        private Dictionary<int, T> _objects;

        public CatalogV2()
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