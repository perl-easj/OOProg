using System.Collections.Generic;
using System.Linq;

namespace SWCClasses.DataStructures
{
    public class GenericCatalog<TKey, TValue> : IGenericCatalog<TKey, TValue>
    {
        private Dictionary<TKey, TValue> _items;

        public GenericCatalog()
        {
            _items = new Dictionary<TKey, TValue>();
        }

        public int Count
        {
            get { return _items.Count; }
        }

        public List<TValue> All
        {
            get { return _items.Values.ToList(); }
        }

        public void Insert(TKey key, TValue val)
        {
            if (!_items.ContainsKey(key))
            {
                _items.Add(key, val);
            }
        }

        public TValue Read(TKey key)
        {
            return _items.ContainsKey(key) ? _items[key] : default(TValue);
        }

        public void Update(TKey key, TValue val)
        {
            if (_items.ContainsKey(key))
            {
                _items[key] = val;
            }
        }

        public void Delete(TKey key)
        {
            _items.Remove(key);
        }
    }
}