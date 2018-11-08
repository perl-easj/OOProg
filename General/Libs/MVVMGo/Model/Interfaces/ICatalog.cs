using System.Collections.Generic;

namespace Model.Interfaces
{
    /// <summary>
    /// This is a general interface for a Catalog, which is intended
    /// to manage a collection of domain objects, and provide CRUD
    /// methods which can be called by objects in the View Model layer.
    /// Note that since the Catalog may (or may not) be responsible for
    /// creating actual domain model objects based on transformed data
    /// (e.g. view model data), the type parameter TData is "neutral" i.e.
    /// no assumption is made about the kind of data TData represents.
    /// /// </summary>
    /// <typeparam name="TData">Type of data used in method definitions</typeparam>
    public interface ICatalog<TData> : ICatalogChangedEvent
    {
        /// <summary>
        /// Returns all objects in the catalog
        /// </summary>
        List<TData> All { get; }

        /// <summary>
        /// Creates/inserts a new domain object in the catalog, 
        /// based on the data provided as argument.
        /// </summary>
        /// <param name="vdObj">
        /// Object containing data for domain object creation
        /// (or possibly the domain object itself).
        /// </param>
        void Create(TData vdObj);

        /// <summary>
        /// Reads the object in the catalog which
        /// matches the given key (if any)
        /// </summary>
        TData Read(int key);

        /// <summary>
        /// Updates the given object in the catalog.
        /// The provided key value will be the key 
        /// for the (updated) object in the catalog.
        /// </summary>
        void Update(TData vdObj, int key);

        /// <summary>
        /// Deletes the object matching the key 
        /// (if any) from the catalog.
        /// </summary>
        void Delete(int key);
    }
}