using System;
using System.Collections.Generic;
using DataAccess.DomainClasses;

namespace DataAccess.DBToolClasses
{
    /// <summary>
    /// This class represents a "legacy" tool for database access.
    /// The tool can access all records from a database, which are of type T.
    /// Objects must implement IHasKey in order to be used with DBTool.
    /// </summary>
    public class DBTool<T> where T : class, IHasKey
    {
        #region Instance fields and Constants
        private const int NullKey = default(int);
        private List<T> _objects;
        #endregion

        #region Constructor
        public DBTool()
        {
            _objects = new List<T>();
        }
        #endregion

        #region Public methods (i.e. the DBTool "interface")
        /// <summary>
        /// Returns the number of records (of type T) in the database.
        /// </summary>
        public int NoOfRecords()
        {
            return _objects.Count;
        }

        /// <summary>
        /// Read all records (of type T) from the database.
        /// </summary>
        public void ReadFromDB()
        {
            _objects.Clear();
            foreach (var record in Database.Ínstance.AllRecords)
            {
                if (record.GetType() == typeof(T))
                {
                    _objects.Add((T)record);
                }
            }
        }

        /// <summary>
        /// Write all records (of type T) to the database.
        /// </summary>
        public void WriteToDB()
        {
            List<object> newRecords = new List<object>();

            // Pick up all non-T records from database
            foreach (var record in Database.Ínstance.AllRecords)
            {
                if (record.GetType() != typeof(T))
                {
                    newRecords.Add(record);
                }
            }

            // Add all current objects (of type T)
            foreach (var obj in _objects)
            {
                newRecords.Add(obj);
            }

            // Now call Replace, with the "sum" of existing non-T
            // objects, and the new objects of type T.
            Database.Ínstance.Replace(newRecords);
        }

        /// <summary>
        /// Insert a single new record into the database.
        /// </summary>
        public void InsertRecord(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentException($"InsertRecord: Null record not allowed");
            }
            if (obj.Key == NullKey)
            {
                throw new ArgumentException($"InsertRecord: Null key not allowed");
            }
            if (KeyExists(obj.Key))
            {
                throw new ArgumentException($"InsertRecord: Entry with key {obj.Key} already exists");
            }

            _objects.Add(obj);
        }

        /// <summary>
        /// Get a single record from the database.
        /// </summary>
        public T GetRecord(int key)
        {
            if (key == NullKey)
            {
                throw new ArgumentException($"GetRecord: Null key not allowed");
            }

            return LookupRecord(key);
        }

        /// <summary>
        /// Get all keys from the objects (of type T) in the database.
        /// </summary>
        public List<int> GetAllKeys()
        {
            List<int> dbKeys = new List<int>();
            for (int i = 0; i < _objects.Count; i++)
            {
                dbKeys.Add(_objects[i].Key);
            }
            return dbKeys;
        }

        /// <summary>
        /// Update a single record.
        /// </summary>
        public void UpdateRecord(T oldObj, T newObj)
        {
            if (oldObj == null || newObj == null)
            {
                throw new ArgumentException($"UpdateRecord: Null records not allowed");
            }
            if (oldObj.Key == NullKey || newObj.Key == NullKey)
            {
                throw new ArgumentException($"UpdateRecord: Null key not allowed");
            }
            if (!KeyExists(oldObj.Key))
            {
                throw new ArgumentException($"UpdateRecord: Old object does not exist");
            }
            if (oldObj.Key != newObj.Key)
            {
                throw new ArgumentException($"UpdateRecord: Keys for old and new object don't match");
            }

            DeleteRecord(oldObj.Key);
            InsertRecord(newObj);
        }

        /// <summary>
        /// Remove a single record from the database.
        /// </summary>
        public void RemoveRecord(int key)
        {
            DeleteRecord(key);
        }
        #endregion

        #region Private helper methods
        /// <summary>
        /// Returns whether or not an object with the given key exists.
        /// </summary>
        private bool KeyExists(int key)
        {
            return LookupRecord(key) != null;
        }

        /// <summary>
        /// Returns the object with the given key (or null if no such object exists).
        /// </summary>
        private T LookupRecord(int key)
        {
            for (int i = 0; i < _objects.Count; i++)
            {
                if (_objects[i].Key == key) return _objects[i];
            }
            return null;
        }

        /// <summary>
        /// Removes the object with the given key (if such an object exists).
        /// </summary>
        private void DeleteRecord(int key)
        {
            for (int i = 0; i < _objects.Count; i++)
            {
                if (_objects[i].Key == key)
                {
                    _objects.RemoveAt(i);
                }
            }
        } 
        #endregion
    }
}