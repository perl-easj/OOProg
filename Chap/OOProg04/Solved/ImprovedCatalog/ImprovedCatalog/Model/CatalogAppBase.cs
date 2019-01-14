using ImprovedCatalog.CatalogBaseClasses.Catalogs;

namespace ImprovedCatalog.Model
{
    /// <summary>
    /// Application-wide base class for domain-specific Catalog classes.
    /// By introducing this layer, we can change the behavior of all
    /// domain-specific Catalog classes with a single change.
    /// </summary>
    /// <typeparam name="K">Type for key for values stored in catalog</typeparam>
    /// <typeparam name="V">Type for values stored in catalog</typeparam>
    public class CatalogAppBase<K, V> : EnumerableCatalog<K, V>
    {
        public CatalogAppBase(bool loadTestData = false)
            : base(loadTestData)
        {
        }
    }
}