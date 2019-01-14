namespace ImprovedCatalog.CatalogBaseClasses.Interfaces
{
    /// <summary>
    /// This interface defines indexing functionality for a catalog.
    /// </summary>
    /// <typeparam name="K">Type for key for values stored in catalog</typeparam>
    /// <typeparam name="V">Type for values stored in catalog</typeparam>
    public interface IIndexableCatalog<in K, out V>
    {
        /// <summary>
        /// When invoked with a key value, the indexer will either:
        /// 1) Return a reference to the value for which the given key is the key.
        /// 2) If no such value exists, return default(V).
        /// </summary>
        /// <param name="key">Key for which we wish to retrieve a value.</param>
        /// <returns>Value matching the key, or default(V)</returns>
        V this[K key] { get; }
    }
}