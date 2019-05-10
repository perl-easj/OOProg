using System;
using System.Collections;
using System.Collections.Generic;

namespace AdvLINQ
{
    public class Catalog<K, V> : IEnumerable<V>
    {
        private Dictionary<K, V> _objects;
        private Func<V, bool> _selectorFunc;

        public Catalog(Func<V, bool> selectorFunc, bool loadTestData = false)
        {
            _objects = new Dictionary<K, V>();
            _selectorFunc = selectorFunc;

            if (loadTestData) LoadTestData();
        }

        public Catalog(bool loadTestData = false)
        {
            _objects = new Dictionary<K, V>();
            _selectorFunc = v => true;

            if (loadTestData) LoadTestData();
        }

        public IEnumerable<V> All
        {
            get { return _objects.Values; }
        }

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

        public void Delete(K key)
        {
            _objects.Remove(key);
        }

        public V Read(K key)
        {
            return _objects.ContainsKey(key) ? _objects[key] : default(V);
        }

        public V this[K key]
        {
            get { return Read(key); }
        }

        public virtual IEnumerator<V> GetEnumerator()
        {
            foreach (V val in All)
            {
                if (_selectorFunc(val))
                {
                    yield return val;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        protected virtual void LoadTestData()
        {
        }

        protected virtual void InsertKeyAlreadyExistsHandler(K key)
        {

        }
    }
}