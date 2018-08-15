using DataAccess.DomainClasses;

namespace DataAccess.DataSource
{
    /// <summary>
    /// This class makes it possible to adapt a domain 
    /// class which does not implement IHasKey.
    /// </summary>
    /// <typeparam name="T">Type of domain class being adapted</typeparam>
    public class KeyAdapter<T> : IHasKey
    {
        #region Instance fields
        private int _key;
        private T _obj;
        #endregion

        #region Constructor
        public KeyAdapter(T obj, int key)
        {
            _obj = obj;
            _key = key;
        }
        #endregion

        #region Properties
        public int Key
        {
            get { return _key; }
            set { _key = value; }
        }

        public T Data
        {
            get { return _obj; }
        } 
        #endregion
    }
}