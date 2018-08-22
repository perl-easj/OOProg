using System.Collections.Generic;

namespace AddOns.Security.Interfaces
{
    /// <summary>
    /// Interface for managing access types to 
    /// specific application elements.
    /// </summary>
    public interface IItemAccess
    {
        /// <summary>
        /// Add an access type to a specific application element.
        /// That is; if a user has the specified access type, the
        /// user has access to the application element.
        /// </summary>
        /// <param name="itemName">
        /// Application element to which an access type is added.
        /// </param>
        /// <param name="accessType">
        /// Access type to add.
        /// </param>
        void AddAccessType(string itemName, AccessType accessType);

        /// <summary>
        /// Retrives all access types to the given application element.
        /// </summary>
        /// <param name="itemName">
        /// Application element for which to retrieve access types.
        /// </param>
        /// <returns>
        /// Access types to given application element.
        /// </returns>
        List<AccessType> GetAccessTypes(string itemName);
    }
}