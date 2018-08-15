using System.Collections.Generic;

namespace DataAccess.DataSource
{
    /// <summary>
    /// Interface for a more modern data source accessor.
    /// </summary>
    /// <typeparam name="TKey">Type for object key</typeparam>
    /// <typeparam name="T">Type for domain object</typeparam>
    public interface IDataSource<TKey, T>
    {
        /// <summary>
        /// Returns the number of objects in the data source.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Returns all domain objects (plus the corresponding keys) 
        /// currently stored in the data source.
        /// </summary>
        Dictionary<TKey, T> All { get; }

        /// <summary>
        /// Store a single new domain object in the data source.
        /// </summary>
        /// <param name="key">Key for domain object</param>
        /// <param name="data">Domain object</param>
        void Create(TKey key, T data);

        /// <summary>
        /// Read a single domain object from the data source, 
        /// i.e. the object which matches the given key.
        /// Null is returned if no such object is found.
        /// </summary>
        /// <param name="key">Key for domain object to read</param>
        /// <returns>Read domain object (or null)</returns>
        T Read(TKey key);

        /// <summary>
        /// Update a single domain object.
        /// </summary>
        /// <param name="key">Key for object to update</param>
        /// <param name="data">Domain object which will replace the existing object</param>
        void Update(TKey key, T data);

        /// <summary>
        /// Delete a single domain object from the data source.
        /// </summary>
        /// <param name="key">Key for object to delete</param>
        void Delete(TKey key);

        /// <summary>
        /// Load all domain objects from permanent 
        /// storage into the data source.
        /// </summary>
        void Load();

        /// <summary>
        /// Save all domain objects in the data source
        /// to permanent storage.
        /// </summary>
        void Save();
    }
}