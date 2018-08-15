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
            // Simple implementation
            get { return _dbToolAdapter.Count; }
        }

        public Dictionary<int, T> All
        {
            get
            {
                Dictionary<int, T> result = new Dictionary<int, T>();

                foreach (var keyAndObj in _dbToolAdapter.All)
                {
                    // For each object from the DBTool adapter 
                    // (these objects MUST implement IHasKey):
                    // 1) "Unwrap" the original domain object (through the Data property)
                    // 2) Add the unwrapped domain object and corresponding key to the result.
                    T obj = Unwrap(keyAndObj.Value);
                    result.Add(keyAndObj.Key, obj);
                }

                return result;
            }
        }
        #endregion

        #region Methods (from IDataSource interface)
        public void Create(int key, T data)
        {
            // Wrap the domain object in a KeyAdapter object,
            // and then call Create on the DBTool adapter.
            _dbToolAdapter.Create(key, Wrap(data, key));
        }

        public T Read(int key)
        {
            // Unwrap the domain object from the returned KeyAdapter object,
            // and return it to the caller (or return null if no object was found).
            return Unwrap(_dbToolAdapter.Read(key));
        }

        public void Update(int key, T data)
        {
            // Wrap the domain object in a KeyAdapter object,
            // and then call Update on the DBTool adapter.
            _dbToolAdapter.Update(key,Wrap(data, key));
        }

        public void Delete(int key)
        {
            // Simple implementation
            _dbToolAdapter.Delete(key);
        }

        public void Load()
        {
            // Simple implementation
            _dbToolAdapter.Load();
        }

        public void Save()
        {
            // Simple implementation
            _dbToolAdapter.Save();
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