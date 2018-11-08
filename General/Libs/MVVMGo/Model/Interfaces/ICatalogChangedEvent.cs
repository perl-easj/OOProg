using System;

namespace Model.Interfaces
{
    /// <summary>
    /// The event in this interface can be subscribed
    /// to by any object interesting in knowing about
    /// changes in the catalog implementing the interface.
    /// </summary>
    public interface ICatalogChangedEvent
    {
        /// <summary>
        /// The event argument is the key for
        /// the object which the change concerns.
        /// </summary>
        event Action<int> CatalogChanged;
    }
}