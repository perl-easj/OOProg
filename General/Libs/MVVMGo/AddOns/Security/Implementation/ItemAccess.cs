using System;
using System.Collections.Generic;
using AddOns.Security.Interfaces;

namespace AddOns.Security.Implementation
{
    /// <summary>
    /// Implementation of the IItemAccess interface
    /// </summary>
    public class ItemAccess : IItemAccess
    {
        private Dictionary<string, List<AccessType>> _accessDictionary;

        public ItemAccess()
        {
            _accessDictionary = new Dictionary<string, List<AccessType>>();
        }

        #region Methods
        /// <summary>
        /// Add an access type to a specific application element.
        /// That is; if a user has the specified access type, the
        /// user has access to the application element. If the access
        /// type has already been specified, an exception is thrown.
        /// </summary>
        /// <param name="itemName">
        /// Application element to which an access type is added.
        /// </param>
        /// <param name="accessType">
        /// Access type to add.
        /// </param>
        public void AddAccessType(string itemName, AccessType accessType)
        {
            // Add the item, if not already present
            if (!_accessDictionary.ContainsKey(itemName))
            {
                _accessDictionary.Add(itemName, new List<AccessType>());
            }

            // Add the access type, if not already present
            if (_accessDictionary[itemName].Contains(accessType))
            {
                throw new ArgumentException(nameof(AddAccessType));
            }

            _accessDictionary[itemName].Add(accessType);
        }

        /// <summary>
        /// Retrives all access types to the given application element.
        /// Note that it is not considered an error if no access types
        /// are found; this is interpreted as "no access".
        /// </summary>
        /// <param name="itemName">
        /// Application element for which to retrieve access types.
        /// </param>
        /// <returns>
        /// Access types to given application element.
        /// </returns>
        public List<AccessType> GetAccessTypes(string itemName)
        {
            return _accessDictionary.ContainsKey(itemName) ? _accessDictionary[itemName] : new List<AccessType>();
        }

        /// <summary>
        /// Mainly provided for debugging purposes.
        /// </summary>
        public override string ToString()
        {
            string toStr = "";

            foreach (var item in _accessDictionary)
            {
                toStr = toStr + item.Key + " { ";

                foreach (var access in item.Value)
                {
                    toStr = toStr + access + " ";
                }

                toStr = toStr + "}\n";
            }

            return toStr;
        }
        #endregion
    }
}