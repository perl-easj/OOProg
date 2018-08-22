using System.Collections.Generic;

namespace Model.Interfaces
{
    /// <summary>
    /// This is a general interface for a Catalog, which is intended
    /// to manage a collection of domain objects, and provide CRUD
    /// methods which can be called by objects in the View Model layer.
    /// Note that since the CRUD methods will be called by objects 
    /// in the View Model layer, the methods generally operate on
    /// objects of a view data type.    
    /// /// </summary>
    /// <typeparam name="TViewData">Type of view data</typeparam>
    public interface ICatalog<TViewData> : ICatalogChangedEvent
    {
        /// <summary>
        /// Returns all objects in the catalog
        /// </summary>
        List<TViewData> All { get; }

        /// <summary>
        /// Creates a new domain object in the catalog, 
        /// based on the data provided in the view data object
        /// </summary>
        /// <param name="vdObj">
        /// Object containing data for domain object creation
        /// </param>
        void Create(TViewData vdObj);

        /// <summary>
        /// Reads the object in the catalog which
        /// matches the given key (if any)
        /// </summary>
        TViewData Read(int key);

        /// <summary>
        /// Updates the given object in the catalog.
        /// The provided key value will be the key 
        /// for the (updated) domain object in the catalog.
        /// </summary>
        void Update(TViewData vdObj, int key);

        /// <summary>
        /// Deletes the domain object matching the key 
        /// (if any) from the catalog.
        /// </summary>
        void Delete(int key);
    }
}