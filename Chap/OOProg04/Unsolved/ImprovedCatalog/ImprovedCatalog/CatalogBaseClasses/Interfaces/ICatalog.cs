namespace ImprovedCatalog.CatalogBaseClasses.Interfaces
{
    /// <summary>
    /// Interface for simple Catalog-style functionality. It is assumed
    /// that a key exists for any value stored in the Catalog
    /// </summary>
    /// <typeparam name="K">Type for key for values stored in catalog</typeparam>
    /// <typeparam name="V">Type for values stored in catalog</typeparam>
    public interface ICatalog<in K, V>
    {
        /// <summary>
        /// When called with a key value, Read will either:
        /// 1) Return a reference to the value for which the given key is the key.
        /// 2) If no such value exists, return default(V).
        /// </summary>
        /// <param name="key">Key for which we wish to retrieve a value.</param>
        /// <returns>Value matching the key, or default(V)</returns>
        V Read(K key);

        /// <summary>
        /// This method inserts the given value into the catalog, using the given
        /// key as the key for the value. The value is not inserted if the key
        /// already exists in the catalog. No further assumptions about handling of
        /// the latter scenario are made. 
        /// </summary>
        /// <param name="key">Key for the value being inserted</param>
        /// <param name="value">Value being inserted</param>
        void Insert(K key, V value);

        /// <summary>
        /// Deletes the value for which the given key is the key. If no such value
        /// exists, no action is taken. No further assumptions about handling of the
        /// latter scenario are made.
        /// </summary>
        /// <param name="key">Key for the value being deleted</param>
        void Delete(K key);
    }
}