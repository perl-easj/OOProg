using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SWCClasses.MVVM
{
    /// <summary>
    /// A domain-specific data view model
    /// class can inherit from this class
    /// </summary>
    /// <typeparam name="T">Type of domain class</typeparam>
    public abstract class DataViewModelBase<T> : INotifyPropertyChanged
        where T : class
    {
        #region Instance fields
        /// <summary>
        /// The domain object encapsulated by the
        /// data view model object
        /// </summary>
        public T DomainObject;
        #endregion

        #region Constructor
        /// <summary>
        /// A derived class must call this constructor
        /// </summary>
        /// <param name="obj">Encapsulated domain object</param>
        protected DataViewModelBase(T obj)
        {
            DomainObject = obj;
        } 
        #endregion

        #region OnPropertyChanged code
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}