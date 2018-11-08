using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Data.InMemory.Interfaces;
using Model.Interfaces;
using ViewModel.Page.Interfaces;

namespace ViewModel.Page.Implementation
{
    /// <summary>
    /// Implementation of the IPageViewModel interface. Will refer to a Catalog instance,
    /// from which data is retrieved and made available to a view using this view model.
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public abstract class PageViewModelBase<TData> : 
        IDataWrapper<TData>, 
        IPageViewModel<TData>
        where TData : class, ICopyable, new()
    {
        #region Instance fields
        protected ICatalog<TData> Catalog;
        private IDataWrapper<TData> _itemSelected;
        private IDataWrapper<TData> _itemDetails;
        #endregion

        #region Initialisation
        protected PageViewModelBase(ICatalog<TData> catalog)
        {
            Catalog = catalog ?? throw new ArgumentNullException(nameof(catalog));
            _itemSelected = null;
            _itemDetails = null;
        }
        #endregion

        #region IDataWrapper implementation
        /// <summary>
        /// The object referred to by ItemDetails is considered to be the "wrapped" 
        /// view data object. This can be changed in a sub-class, if needed.
        /// </summary>
        public virtual TData DataObject
        {
            get { return ItemDetails?.DataObject; }
        }
        #endregion

        #region IPageViewModel implementation
        public virtual ObservableCollection<IDataWrapper<TData>> ItemCollection
        {
            get { return CreateDataViewModelCollection(Catalog.All); }
        }

        /// <summary>
        /// Standard implementation of bindable property, 
        /// except the call to OnItemSelectionChanged. 
        /// Clients interested in knowing about selection
        /// changes get notified about this change.
        /// </summary>
        public virtual IDataWrapper<TData> ItemSelected
        {
            get { return _itemSelected; }
            set
            {
                _itemSelected = value;
                OnItemSelectionChanged(_itemSelected);
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Standard implementation of bindable property
        /// </summary>
        public IDataWrapper<TData> ItemDetails
        {
            get { return _itemDetails; }
            set
            {
                _itemDetails = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region ViewData creation
        public IDataWrapper<TData> CreateDataViewModelFromNewViewData()
        {
            return CreateDataViewModel(new TData());
        }

        public IDataWrapper<TData> CreateDataViewModelFromClonedViewData(TData obj)
        {
            return CreateDataViewModel(obj.Copy() as TData);
        }

        private ObservableCollection<IDataWrapper<TData>> CreateDataViewModelCollection(List<TData> dataObjects)
        {
            var itemViewModels = new ObservableCollection<IDataWrapper<TData>>();
            foreach (TData obj in dataObjects)
            {
                itemViewModels.Add(CreateDataViewModel(obj));
            }

            return itemViewModels;
        }

        /// <summary>
        /// Must be implemented in derived classes, where specific 
        /// data view model classes are known.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public abstract IDataWrapper<TData> CreateDataViewModel(TData obj);
        #endregion

        #region Event implementation
        /// <summary>
        /// Clients interested in knowing about changes in item 
        /// selection can register at this event.
        /// </summary>
        public event Action<IDataWrapper<TData>> ItemSelectionChanged;
        public virtual void OnItemSelectionChanged(IDataWrapper<TData> vmoWrapper)
        {
            ItemSelectionChanged?.Invoke(vmoWrapper);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}