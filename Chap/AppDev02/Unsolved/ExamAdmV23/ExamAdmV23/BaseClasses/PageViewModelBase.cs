using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ExamAdmV23.BaseClasses
{
    /// <summary>
    /// This class is intended to be a base class for page view model classes. 
    /// A domain-specific class must inherit from this class, and call its 
    /// constructor with a domain-specific catalog object.
    /// </summary>
    public abstract class PageViewModelBase<TDomainClass> : INotifyPropertyChanged
        where TDomainClass : DomainClassBase
    {
        #region Instance fields
        private CatalogBase<TDomainClass> _catalog;
        private DataViewModelBase<TDomainClass> _itemSelected;
        private DeleteCommandBase<TDomainClass, PageViewModelBase<TDomainClass>> _deleteCommand;
        #endregion

        #region Constructor
        /// <summary>
        /// Create the page view model object, with reference
        /// to a catalog object.
        /// </summary>
        protected PageViewModelBase(CatalogBase<TDomainClass> catalog)
        {
            _catalog = catalog;
            _itemSelected = null;
            _deleteCommand = new DeleteCommandBase<TDomainClass, PageViewModelBase<TDomainClass>>(_catalog, this);
        }
        #endregion

        #region Properties for Data Binding
        /// <summary>
        /// Deletion command property. The view can bind 
        /// to this property.
        /// </summary>
        public ICommand DeletionCommand
        {
            get { return _deleteCommand; }
        }

        /// <summary>
        /// Get a collection of data view models.
        /// The view can bind to this property
        /// </summary>
        public List<DataViewModelBase<TDomainClass>> DataViewModelCollection
        {
            get { return GetDataViewModelCollection(_catalog); }
        }

        /// <summary>
        /// The item view model currently selected.
        /// The view can bind to this property
        /// </summary>
        public DataViewModelBase<TDomainClass> ItemSelected
        {
            get { return _itemSelected; }
            set
            {
                _itemSelected = value;
                _deleteCommand.RaiseCanExecuteChanged();
                OnPropertyChanged();
            }
        }
        #endregion

        #region Methods
        public void RefreshDataViewModelCollection()
        {
            OnPropertyChanged(nameof(DataViewModelCollection));
        }

        public List<DataViewModelBase<TDomainClass>> GetDataViewModelCollection(CatalogBase<TDomainClass> catalog)
        {
            List<DataViewModelBase<TDomainClass>> items = new List<DataViewModelBase<TDomainClass>>();

            foreach (TDomainClass obj in catalog.All)
            {
                items.Add(CreateDataViewModel(obj));
            }

            return items;
        }

        public abstract DataViewModelBase<TDomainClass> CreateDataViewModel(TDomainClass obj);
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