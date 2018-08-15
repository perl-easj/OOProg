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
            // Implement this property by using _dbTool
            get { return 0; }
        }

        public Dictionary<int, T> All
        {
            // Implement this property by using _dbTool
            get { return new Dictionary<int, T>(); }
        }
        #endregion

        #region Methods (from IDataSource interface)
        public void Create(int key, T data)
        {
            // Implement this method by using _dbTool
        }

        public T Read(int key)
        {
            // Implement this method by using _dbTool
            return default(T);
        }

        public void Update(int key, T data)
        {
            // Implement this method by using _dbTool
        }

        public void Delete(int key)
        {
            // Implement this method by using _dbTool
        }

        public void Load()
        {
            // Implement this method by using _dbTool
        }

        public void Save()
        {
            // Implement this method by using _dbTool
        }
        #endregion
    }
}