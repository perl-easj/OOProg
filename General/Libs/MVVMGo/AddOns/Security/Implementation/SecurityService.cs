using System;
using System.Collections.Generic;
using AddOns.Security.Interfaces;

namespace AddOns.Security.Implementation
{
    /// <summary>
    /// Implementation of the ISecurityService interface
    /// </summary>
    public class SecurityService : ISecurityService
    {
        public const string AdminUserName = "Admin";

        #region Instance fields
        private IUserType _userTypes;
        private IItemAccess _itemAccess;
        #endregion

        #region Constructor
        public SecurityService(IUserType userType, IItemAccess itemAccess)
        {
            Users = new Dictionary<string, IUser>();
            _userTypes = userType;
            _itemAccess = itemAccess;
            CurrentUserName = User.AnonymousUserName;
            UseLogin = false;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Returns whether the Login functionality 
        /// is used at all.
        /// </summary>
        public bool UseLogin { get; set; }

        /// <summary>
        /// Name of the user currently logged in.
        /// </summary>
        public string CurrentUserName { get; set; }

        /// <summary>
        /// Retrieves all registered users, 
        /// using the user name as key.
        /// </summary>
        protected Dictionary<string, IUser> Users { get; }

        /// <summary>
        /// Retrieves all registered user types, 
        /// as an IUserType reference.
        /// </summary>
        protected IUserType UserTypes
        {
            get { return _userTypes; }
        }

        /// <summary>
        /// Retrieves all registered item access 
        /// specification, as an IItemAccess reference.
        /// </summary>
        protected IItemAccess ItemAccess
        {
            get { return _itemAccess; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Add a new user. If the user has already 
        /// been added, an exception is thrown.
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
        public void AddUser(string userName, string password, string userType)
        {
            if (Users.ContainsKey(userName))
            {
                throw new ArgumentException(nameof(AddUser));
            }

            Users.Add(userName, new User(userName, password, userType));
            _userTypes.AddUserType(userType);
        }

        /// <summary>
        /// Checks if given user name and password match, 
        /// i.e. is the given password the correct password 
        /// for this user. If no user with the given user name 
        /// has been registered, an exception is thrown.
        /// </summary>
        /// <param name="userName">
        /// Name of user.
        /// </param>
        /// <param name="password">
        /// Password to check against user
        /// </param>
        public bool CheckPassword(string userName, string password)
        {
            if (!Users.ContainsKey(userName))
            {
                throw new ArgumentException(nameof(CheckPassword));
            }

            return Users[userName].Password == password;
        }

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
        public void AddItemAccessType(string itemName, AccessType accessType)
        {
            _itemAccess.AddAccessType(itemName, accessType);
        }

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
        public void AddItemAccessTypes(string itemName, List<AccessType> accessTypes)
        {
            foreach (AccessType accessType in accessTypes)
            {
                AddItemAccessType(itemName, accessType);
            }
        }

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
        public void AddUserAccessRight(string userType, string itemName, AccessType accessType)
        {
            _userTypes.AddAccessRight(userType, itemName, accessType);
        }

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
        public void AddUserAccessRights(string userType, string itemName, List<AccessType> accessTypes)
        {
            foreach (AccessType accessType in accessTypes)
            {
                AddUserAccessRight(userType, itemName, accessType);
            }
        }

        /// <summary>
        /// Returns whether or not the current user has 
        /// access to the given application element.
        /// </summary>
        /// <param name="itemName">
        /// Application element identifier.
        /// </param>
        public bool IsActionAllowedForCurrentUser(string itemName)
        {
            return IsActionAllowed(CurrentUserName, itemName);
        }

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
        public virtual bool IsActionAllowed(string userName, string itemName)
        {
            if (userName == AdminUserName)
            {
                return true;
            }

            if (!Users.ContainsKey(userName))
            {
                return false;
            }

            foreach (AccessType accessType in ItemAccess.GetAccessTypes(itemName))
            {
                if (UserTypes.HasAccessRight(Users[userName].UserType, itemName, accessType))
                {
                    return true;
                }
            }

            return false;
        }
        #endregion
    }
}