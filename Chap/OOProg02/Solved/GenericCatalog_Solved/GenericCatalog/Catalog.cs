using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCatalog
{
    public class Catalog<TKey, TValue>
    {
        private Dictionary<TKey, TValue> _items;

        public Catalog()
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

        public void Insert(TKey key, TValue obj)
        {
            if (!_items.ContainsKey(key))
            {
                _items.Add(key, obj);
            }
        }

        public void Delete(TKey key)
        {
            _items.Remove(key);
        }

        public void PrintAll()
        {
            foreach (var item in _items.Values)
            {
                Console.WriteLine(item);
            }
        }
    }
}