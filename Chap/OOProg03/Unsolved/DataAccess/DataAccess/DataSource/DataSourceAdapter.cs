using System.Collections.Generic;

namespace DataAccess.DataSource
{
    /// <summary>
    /// This class implements an adapter for the DBToolAdapter. This is done
    /// to enable use of domain objects which do NOT implement IHasKey.
    /// The adapter class must
    /// 1) Implement the IDataSource interface (with TKey = int).
    /// 2) Adapt a DBToolAdapter instance, by using the KeyAdapter class.
    /// </summary>
    /// <typeparam name="T">Type of domain object (does NOT need to implement IHasKey)</typeparam>
    public class DataSourceAdapter<T> : IDataSource<int, T> where T : class
    {
        #region Instance fields
        private DBToolAdapter<KeyAdapter<T>> _dbToolAdapter;
        #endregion

        #region Constructor
        public DataSourceAdapter()
        {
            _dbToolAdapter = new DBToolAdapter<KeyAdapter<T>>();
        }
        #endregion

        #region Properties (from IDataSource interface)
        public int Count
        {
            // Implement this property by using _dbToolAdapter
            get { return 0; }
        }

        public Dictionary<int, T> All
        {
            // Implement this property by using _dbToolAdapter
            get { return new Dictionary<int, T>(); }
        }
        #endregion

        #region Methods (from IDataSource interface)
        public void Create(int key, T data)
        {
            // Implement this method by using _dbToolAdapter
        }

        public T Read(int key)
        {
            // Implement this method by using _dbToolAdapter
            return default(T);
        }

        public void Update(int key, T data)
        {
            // Implement this method by using _dbToolAdapter
        }

        public void Delete(int key)
        {
            // Implement this method by using _dbToolAdapter
        }

        public void Load()
        {
            // Implement this method by using _dbToolAdapter
        }

        public void Save()
        {
            // Implement this method by using _dbToolAdapter
        }
        #endregion

        #region Private methods for Wrap/Unwrap
        private T Unwrap(KeyAdapter<T> wrappedObj)
        {
            return wrappedObj?.Data;
        }

        private KeyAdapter<T> Wrap(T obj, int key)
        {
            return new KeyAdapter<T>(obj, key);
        } 
        #endregion
    }
}