using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SWCClasses.MVVM
{
    /// <summary>
    /// This class is intended to be a base class for page view model classes. 
    /// A domain-specific class can inherit from this class, and call its 
    /// constructor with a domain-specific catalog object.
    /// </summary>
    public abstract class PageViewModelBase<T> : INotifyPropertyChanged where T : class
    {
        #region Instance fields
        private CatalogBase<T> _catalog;
        private DataViewModelBase<T> _itemSelected;
        #endregion

        #region Constructor
        /// <summary>
        /// Create the page view model object, with reference
        /// to a catalog object.
        /// </summary>
        protected PageViewModelBase(CatalogBase<T> catalog)
        {
            _catalog = catalog;
            _itemSelected = null;
        }
        #endregion

        #region Properties for Data Binding
        /// <summary>
        /// Get a collection of data view models.
        /// The view can bind to this property.
        /// </summary>
        public List<DataViewModelBase<T>> ItemCollection
        {
            get { return GetDataViewModelCollection(_catalog); }
        }

        /// <summary>
        /// The item view model currently selected.
        /// The view can bind to this property.
        /// </summary>
        public DataViewModelBase<T> ItemSelected
        {
            get { return _itemSelected; }
            set
            {
                _itemSelected = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Methods
        public void RefreshDataViewModelCollection()
        {
            OnPropertyChanged(nameof(ItemCollection));
        }

        private List<DataViewModelBase<T>> GetDataViewModelCollection(CatalogBase<T> catalog)
        {
            List<DataViewModelBase<T>> items = new List<DataViewModelBase<T>>();

            foreach (T obj in catalog.All)
            {
                items.Add(CreateDataViewModel(obj));
            }

            return items;
        }

        protected abstract DataViewModelBase<T> CreateDataViewModel(T obj);
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