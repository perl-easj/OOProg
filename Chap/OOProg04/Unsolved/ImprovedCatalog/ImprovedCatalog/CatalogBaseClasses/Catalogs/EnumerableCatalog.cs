using System.Collections;
using System.Collections.Generic;
using ImprovedCatalog.CatalogBaseClasses.Interfaces;

namespace ImprovedCatalog.CatalogBaseClasses.Catalogs
{
    /// <summary>
    /// Class which adds enumerability to the standard Catalog functionality.
    /// The class:
    /// 1) Inherits from IndexableCatalog
    /// 2) Implements the IEnumerableCatalog interface.
    /// </summary>
    /// <typeparam name="K">Type for key for values stored in catalog</typeparam>
    /// <typeparam name="V">Type for values stored in catalog</typeparam>
    public class EnumerableCatalog<K, V> : IndexableCatalog<K, V>, IEnumerableCatalog<V>
    {
        public EnumerableCatalog(bool loadTestData = false) 
            : base(loadTestData)
        {
        }

        public virtual IEnumerator<V> GetEnumerator()
        {
            // TODO - Implement correctly
            return new List<V>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}