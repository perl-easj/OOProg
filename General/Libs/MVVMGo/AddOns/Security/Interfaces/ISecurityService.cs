using System.Collections.Generic;

namespace AddOns.Security.Interfaces
{
    /// <summary>
    /// Interface for management of users and access rights
    /// </summary>
    public interface ISecurityService
    {
        /// <summary>
        /// Returns whether the Login functionality 
        /// is used at all.
        /// </summary>
        bool UseLogin { get; set; }

        /// <summary>
        /// Name of the user currently logged in.
        /// </summary>
        string CurrentUserName { get; set; }

        /// <summary>
        /// Add a new user.
        /// </summary>
        /// <param name="userName">
        /// User name for new user.
        /// </param>
        /// <param name="password">
        /// Password for new user.
        /// </param>
        /// <param name="userType">
        /// User type for new user.
        /// </param>
        void AddUser(string userName, string password, string userType);

        /// <summary>
        /// Checks if given user name and password match, 
        /// i.e. is the given password the correct password 
        /// for this user.
        /// </summary>
        /// <param name="userName">
        /// Name of user.
        /// </param>
        /// <param name="password">
        /// Password to check against user
        /// </param>
        bool CheckPassword(string userName, string password);

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
        void AddItemAccessType(string itemName, AccessType accessType);

        /// <summary>
        /// Add a set of access types to a specific application element.
        /// That is; if a user has one of the specified access types, the
        /// user has access to the application element.
        /// </summary>
        /// <param name="itemName">
        /// Application element to which access types are added.
        /// </param>
        /// <param name="accessTypes">
        /// Access types to add.
        /// </param>
        void AddItemAccessTypes(string itemName, List<AccessType> accessTypes);

        /// <summary>
        /// Add an access right to the user type, 
        /// for a given application element.
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
        void AddUserAccessRight(string userType, string itemName, AccessType accessType);

        /// <summary>
        /// Add a set of access rights to the user type, 
        /// for a given application element.
        /// </summary>
        /// <param name="userType">
        /// User type for which access rights are added.
        /// </param>
        /// <param name="itemName">
        /// Identifier for application element for which 
        /// access rights are specified.
        /// </param>
        /// <param name="accessTypes">
        /// Access types to specific application element.
        /// </param>
        void AddUserAccessRights(string userType, string itemName, List<AccessType> accessTypes);

        /// <summary>
        /// Returns whether or not the current user has 
        /// access to the given application element.
        /// </summary>
        /// <param name="itemName">
        /// Application element identifier.
        /// </param>
        bool IsActionAllowedForCurrentUser(string itemName);

        /// <summary>
        /// Returns whether or not the given user has 
        /// access to the given application element.
        /// </summary>
        /// <param name="userName">
        /// User name for which to check access rights.
        /// </param>
        /// <param name="itemName">
        /// Application element identifier.
        /// </param>
        bool IsActionAllowed(string userName, string itemName);
    }
}