using System.Collections.Generic;

namespace AddOns.Security.Interfaces
{
    /// <summary>
    /// Interface for management of user types
    /// </summary>
    public interface IUserType
    {
        /// <summary>
        /// Add a user type to the set of valid user types.
        /// </summary>
        /// <param name="userType">
        /// User type to add.
        /// </param>
        void AddUserType(string userType);

        /// <summary>
        /// Add an access right for a specific user type.
        /// </summary>
        /// <param name="userType">
        /// User type for which an access right is added.
        /// </param>
        /// <param name="itemName">
        /// Identifier for application element for which 
        /// access rights are specified.
        /// </param>
        /// <param name="accessType">
        /// Access type to specific application element.
        /// </param>
        void AddAccessRight(string userType, string itemName, AccessType accessType);

        /// <summary>
        /// Retrieve access types to a given application element,
        /// for a given user type.
        /// </summary>
        /// <param name="userType">
        /// User type for which access right is retrieved.
        /// </param>
        /// <param name="itemName">
        /// Application element for which access right is retrieved.
        /// </param>
        List<AccessType> GetAccessRights(string userType, string itemName);

        /// <summary>
        /// Returns whether or not a given usertype has a given 
        /// access right to a given application element
        /// </summary>
        /// <param name="userType">
        /// User type
        /// </param>
        /// <param name="itemName">
        /// Application element
        /// </param>
        /// <param name="accessType">
        /// Access type
        /// </param>
        bool HasAccessRight(string userType, string itemName, AccessType accessType);
    }
}