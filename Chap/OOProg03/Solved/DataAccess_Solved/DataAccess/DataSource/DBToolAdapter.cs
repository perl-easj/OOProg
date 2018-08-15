using System;
using System.Collections.Generic;
using DataAccess.DBToolClasses;
using DataAccess.DomainClasses;

namespace DataAccess.DataSource
{
    /// <summary>
    /// This class implements an adapter for the DBTool. That is, the class
    /// 1) Implements the IDataSource interface (with TKey = int).
    /// 2) Adapts a DBTool instance, and thus implements the IDataSource
    ///    methods by calling methods on the DBTool instance.
    /// </summary>
    /// <typeparam name="T">Type of domain object (must implement IHasKey)</typeparam>
    public class DBToolAdapter<T> : IDataSource<int, T> where T : class, IHasKey
    {
        #region Instance fields
        private DBTool<T> _dbTool;
        #endregion

        #region Constructor
        public DBToolAdapter()
        {
            _dbTool = new DBTool<T>();
        }
        #endregion

        #region Properties (from IDataSource interface)
        public int Count
        {
            // Simple implementation
            get { return _dbTool.NoOfRecords(); }
        }

        public Dictionary<int, T> All
        {
            get
            {
                // Get all object keys from DBTool
                List<int> keys = _dbTool.GetAllKeys();

                Dictionary<int, T> result = new Dictionary<int, T>();
                foreach (var key in keys)
                {
                    // Get the record corresponding to a specific key,
                    // and add the (key, object) pair to the result
                    T obj = _dbTool.GetRecord(key);
                    result.Add(key, obj);
                }
                return result;
            }
        }
        #endregion

        #region Methods (from IDataSource interface)
        public void Create(int key, T data)
        {
            // Add the provided key to the domain 
            // object, before calling DBTool.
            data.Key = key;
            _dbTool.InsertRecord(data);
        }

        public T Read(int key)
        {
            // Try to read a record - if unsuccessful, return null.
            try
            {
                return _dbTool.GetRecord(key);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Update(int key, T data)
        {
            // Read the domain object corresponding to 
            // the given key, before calling DBTool.
            T oldData = Read(key);
            _dbTool.UpdateRecord(oldData, data);
        }

        public void Delete(int key)
        {
            // Simple implementation
            _dbTool.RemoveRecord(key);
        }

        public void Load()
        {
            // Simple implementation
            _dbTool.ReadFromDB();
        }

        public void Save()
        {
            // Simple implementation
            _dbTool.WriteToDB();
        } 
        #endregion
    }
}