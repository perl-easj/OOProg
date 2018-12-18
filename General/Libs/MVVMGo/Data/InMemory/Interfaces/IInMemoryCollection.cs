using System.Collections.Generic;

namespace Data.InMemory.Interfaces
{
    /// <summary>
    /// Interface for a key-based in-memory collection, 
    /// supporting insertion, retrieval and deletion.
    /// </summary>
    /// <typeparam name="T">
    /// Type of stored objects. This will typically
    /// be a domain object.
    /// </typeparam>
    public interface IInMemoryCollection<T>
    {
        /// <summary>
        /// Returns all objects in the collection
        /// </summary>
        List<T> All { get; }

        /// <summary>
        /// Inserts the given object into the collection.
        /// The "replaceKey" parameter controls if the
        /// collection should replace the key with an
        /// internally managed key.
        /// </summary>
        /// <returns>
        /// The key with which the element was inserted
        /// into the collection
        /// </returns>
        int Insert(T obj, KeyManagementStrategyType keyManagement = KeyManagementStrategyType.CollectionDecides);

        /// <summary>
        /// Reads the object in the collection which
        /// matches the given key (if any)
        /// </summary>
        T Get(int key);

        /// <summary>
        /// Reads the object in the collection which
        /// matches the given key (if any)
        /// </summary>
        T this[int key] { get; }

        /// <summary>
        /// Deletes the object matching the key (if any)
        /// from the collection.
        /// </summary>
        void Remove(int key);

        /// <summary>
        /// Replaces the existing object with the given key with the new object
        /// </summary>
        void Replace(int key, T obj);

        /// <summary>
        /// Inserts all the given objects into the collection.
        /// The "replaceKey" parameter controls if the
        /// collection should replace the keys with
        /// internally managed keys.
        /// </summary>
        void InsertAll(List<T> objects, KeyManagementStrategyType keyManagement = KeyManagementStrategyType.CollectionDecides);

        /// <summary>
        /// Replaces all objects currently in the collection,
        /// with all the given objects.
        /// The "replaceKey" parameter controls if the
        /// collection should replace the keys with
        /// internally managed keys.
        /// </summary>
        void ReplaceAll(List<T> objects, KeyManagementStrategyType keyManagement = KeyManagementStrategyType.CollectionDecides);

        /// <summary>
        /// Delete all objects from the collection.
        /// </summary>
        void RemoveAll();
    }
}