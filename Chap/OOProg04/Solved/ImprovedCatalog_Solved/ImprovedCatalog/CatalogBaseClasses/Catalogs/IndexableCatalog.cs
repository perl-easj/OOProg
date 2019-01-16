using ImprovedCatalog.CatalogBaseClasses.Interfaces;

namespace ImprovedCatalog.CatalogBaseClasses.Catalogs
{
    /// <summary>
    /// Class which adds indexing functionality to the standard Catalog functionality.
    /// The class:
    /// 1) Inherits from Catalog
    /// 2) Implements the IIndexableCatalog interface.
    /// </summary>
    /// <typeparam name="K">Type for key for values stored in catalog</typeparam>
    /// <typeparam name="V">Type for values stored in catalog</typeparam>
    public class IndexableCatalog<K, V> : Catalog<K, V>, IIndexableCatalog<K, V>
    {
        public IndexableCatalog(bool loadTestData = false) 
            : base(loadTestData)
        {           
        }


        /// <inheritdoc />
        /// <summary>
        /// [] is implemented simply by calling Read with the given key.
        /// </summary>
        public V this[K key]
        {
            get { return Read(key); }
        }
    }
}