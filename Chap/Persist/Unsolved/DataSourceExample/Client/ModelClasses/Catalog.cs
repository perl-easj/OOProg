using System;
using System.Collections.Generic;

namespace Client
{
    /// <summary>
    /// Implementation of a single Catalog, i.e. a 
    /// collection of objects of one specific type
    /// Responsibilities:
    /// 1) Perform Catalog-wide operations like 
    ///    Load and All
    /// </summary>
    /// <typeparam name="T">
    /// Type of objects stored in Catalog
    /// </typeparam>
    public class Catalog<T> : ICatalog<T>
    {
        private IDataSourceAsync<T> _source;
        private List<T> _data;

        public Catalog(IDataSourceAsync<T> source)
        {
            _source = source;
            _data = new List<T>();
        }

        public void Load()
        {
            _data = _source.Load().Result;
        }

        public List<T> All
        {
            get { return _data; }
        }
    }
}