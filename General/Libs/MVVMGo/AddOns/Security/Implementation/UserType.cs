using System;
using System.Collections.Generic;
using AddOns.Security.Interfaces;

namespace AddOns.Security.Implementation
{
    /// <summary>
    /// Implementation of the IUserType interface
    /// </summary>
    public class UserType : IUserType
    {
        private Dictionary<string, IItemAccess> _userTypeAccess;

        public UserType()
        {
            _userTypeAccess = new Dictionary<string, IItemAccess>();
        }

        #region Methods
        /// <summary>
        /// Add a user type to the set of valid user types. 
        /// If the user type has already been added, 
        /// an exception is thrown.
        /// </summary>
        /// <param name="userType">
        /// User type to add.
        /// </param>
        public void AddUserType(string userType)
        {
            if (_userTypeAccess.ContainsKey(userType))
            {
                throw new ArgumentException(nameof(AddUserType));
            }

            _userTypeAccess.Add(userType, new ItemAccess());
        }

        /// <summary>
        /// Add an access right for a specific user type. 
        /// If an unknown user type is specified, an 
        /// exception is thrown.
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
        public void AddAccessRight(string userType, string itemName, AccessType accessType)
        {
            if (!_userTypeAccess.ContainsKey(userType))
            {
                throw new ArgumentException(nameof(AddAccessRight));
            }

            _userTypeAccess[userType].AddAccessType(itemName, accessType);
        }

        /// <summary>
        /// Retrieve access types to a given application element,
        /// for a given user type. If an unknown user type is
        /// specified, an exception is thrown.
        /// </summary>
        /// <param name="userType">
        /// User type for which access right is retrieved.
        /// </param>
        /// <param name="itemName">
        /// Application element for which access right is retrieved.
        /// </param>
        public List<AccessType> GetAccessRights(string userType, string itemName)
        {
            if (!_userTypeAccess.ContainsKey(userType))
            {
                throw new ArgumentException(nameof(GetAccessRights));
            }

            return _userTypeAccess[userType].GetAccessTypes(itemName);
        }

        /// <summary>
        /// Returns whether or not a given usertype has 
        /// a given access right to a given application 
        /// element. If an unknown user type is specified, 
        /// an exception is thrown.
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
        public bool HasAccessRight(string userType, string itemName, AccessType accessType)
        {
            List<AccessType> accessTypes = GetAccessRights(userType, itemName);
            return accessTypes.Contains(accessType);
        }
        #endregion
    }
}